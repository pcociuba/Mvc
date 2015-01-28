﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Net.Http.Headers;

namespace Microsoft.AspNet.Mvc.Xml
{
    /// <summary>
    /// This class handles deserialization of input XML data
    /// to strongly-typed objects using <see cref="XmlSerializer"/>
    /// </summary>
    public class XmlSerializerInputFormatter : IInputFormatter
    {
        private readonly XmlDictionaryReaderQuotas _readerQuotas = FormattingUtilities.GetDefaultXmlReaderQuotas();
        private IWrapperProviderFactoryProvider _wrapperProviderFactoryProvider;

        /// <summary>
        /// Initializes a new instance of XmlSerializerInputFormatter.
        /// </summary>
        public XmlSerializerInputFormatter()
        {
            SupportedEncodings = new List<Encoding>();
            SupportedEncodings.Add(Encodings.UTF8EncodingWithoutBOM);
            SupportedEncodings.Add(Encodings.UTF16EncodingLittleEndian);

            SupportedMediaTypes = new List<MediaTypeHeaderValue>();
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/xml"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/xml"));

            WrapperProviderFactoryProvider = new DefaultWrapperProviderFactoryProvider();
        }

        /// <summary>
        /// Gets or sets the provider which gives a list of <see cref="IWrapperProviderFactory"/> to
        /// provide the wrapping type for de-serialization.
        /// </summary>
        public IWrapperProviderFactoryProvider WrapperProviderFactoryProvider
        {
            get
            {
                return _wrapperProviderFactoryProvider;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _wrapperProviderFactoryProvider = value;
            }
        }

        /// <inheritdoc />
        public IList<MediaTypeHeaderValue> SupportedMediaTypes { get; private set; }

        /// <inheritdoc />
        public IList<Encoding> SupportedEncodings { get; private set; }

        /// <summary>
        /// Indicates the acceptable input XML depth.
        /// </summary>
        public int MaxDepth
        {
            get { return _readerQuotas.MaxDepth; }
            set { _readerQuotas.MaxDepth = value; }
        }

        /// <summary>
        /// The quotas include - DefaultMaxDepth, DefaultMaxStringContentLength, DefaultMaxArrayLength,
        /// DefaultMaxBytesPerRead, DefaultMaxNameTableCharCount
        /// </summary>
        public XmlDictionaryReaderQuotas XmlDictionaryReaderQuotas
        {
            get { return _readerQuotas; }
        }

        /// <inheritdoc />
        public bool CanRead(InputFormatterContext context)
        {
            var contentType = context.ActionContext.HttpContext.Request.ContentType;
            MediaTypeHeaderValue requestContentType;
            if (!MediaTypeHeaderValue.TryParse(contentType, out requestContentType))
            {
                return false;
            }

            return SupportedMediaTypes
                            .Any(supportedMediaType => supportedMediaType.IsSubsetOf(requestContentType));
        }

        /// <summary>
        /// Reads the input XML.
        /// </summary>
        /// <param name="context">The input formatter context which contains the body to be read.</param>
        /// <returns>Task which reads the input.</returns>
        public async Task<object> ReadAsync(InputFormatterContext context)
        {
            var request = context.ActionContext.HttpContext.Request;
            if (request.ContentLength == 0)
            {
                return GetDefaultValueForType(context.ModelType);
            }

            return await ReadInternal(context);
        }

        /// <summary>
        /// Called during deserialization to get the <see cref="XmlReader"/>.
        /// </summary>
        /// <param name="readStream">The <see cref="Stream"/> from which to read.</param>
        /// <returns>The <see cref="XmlReader"/> used during deserialization.</returns>
        protected virtual XmlReader CreateXmlReader([NotNull] Stream readStream)
        {
            return XmlDictionaryReader.CreateTextReader(
                readStream, _readerQuotas);
        }

        /// <summary>
        /// Called during deserialization to get the <see cref="XmlSerializer"/>.
        /// </summary>
        /// <returns>The <see cref="XmlSerializer"/> used during deserialization.</returns>
        protected virtual XmlSerializer CreateXmlSerializer(Type type)
        {
            return new XmlSerializer(type);
        }

        private object GetDefaultValueForType(Type modelType)
        {
            if (modelType.GetTypeInfo().IsValueType)
            {
                return Activator.CreateInstance(modelType);
            }

            return null;
        }

        private Task<object> ReadInternal(InputFormatterContext context)
        {
            var request = context.ActionContext.HttpContext.Request;

            using (var xmlReader = CreateXmlReader(new DelegatingStream(request.Body)))
            {
                var type = context.ModelType;

                IWrapperProvider wrapperProvider = FormattingUtilities.GetWrapperProvider(
                                                                WrapperProviderFactoryProvider.WrapperProviderFactories,
                                                                new WrapperProviderContext(
                                                                                        declaredType: type,
                                                                                        isSerialization: false));

                if (wrapperProvider != null && wrapperProvider.WrappingType != null)
                {
                    type = wrapperProvider.WrappingType;
                }

                var serializer = CreateXmlSerializer(type);

                var deserializedObject = serializer.Deserialize(xmlReader);

                // Unwrap only if the original type was wrapped.
                if (type != context.ModelType)
                {
                    IUnwrappable unwrappable = deserializedObject as IUnwrappable;
                    if (unwrappable != null)
                    {
                        deserializedObject = unwrappable.Unwrap(declaredType: context.ModelType);
                    }
                }

                return Task.FromResult(deserializedObject);
            }
        }
    }
}