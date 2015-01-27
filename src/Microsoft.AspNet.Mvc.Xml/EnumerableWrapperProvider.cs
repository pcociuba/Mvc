// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class EnumerableWrapperProvider : IWrapperProvider
    {
        private readonly WrapperProviderContext _context;
        private readonly Type _sourceIEnumerableGenericType;
        private readonly IEnumerable<IWrapperProviderFactory> _wrapperProviderFactories;

        public EnumerableWrapperProvider(
            [NotNull] Type sourceIEnumerableGenericType,
            IEnumerable<IWrapperProviderFactory> wrapperProviderFactories,
            [NotNull] WrapperProviderContext context)
        {
            _sourceIEnumerableGenericType = sourceIEnumerableGenericType;
            _wrapperProviderFactories = wrapperProviderFactories;
            _context = context;
        }

        /// <inheritdoc />
        public Type GetWrappingType([NotNull] Type declaredType)
        {
            IWrapperProvider elementWrapperProvider = null;
            return GetWrappingEnumerableType(out elementWrapperProvider);
        }

        /// <inheritdoc />
        public object Wrap(object original)
        {
            if (original != null)
            {
                IWrapperProvider elementWrapperProvider = null;
                var wrappingEnumerableType = GetWrappingEnumerableType(out elementWrapperProvider);

                var wrappingEnumerableTypeConstructor = wrappingEnumerableType.GetConstructor(new[]
                    {
                        _sourceIEnumerableGenericType,
                        typeof(IWrapperProvider)
                    });

                return wrappingEnumerableTypeConstructor.Invoke(new object[]
                    {
                        original,
                        elementWrapperProvider
                    });
            }

            return null;
        }

        private Type GetWrappingEnumerableType(out IWrapperProvider elementWrapperProvider)
        {
            var declaredElementType = _sourceIEnumerableGenericType.GetGenericArguments()[0];

            // Since the T itself could be wrapped, get the wrapping type for it
            var wrapperProviderContext = new WrapperProviderContext(declaredElementType, _context.IsSerialization);

            var wrappedOrDeclaredElementType = declaredElementType;

            elementWrapperProvider = null;
            foreach (var wrapperProviderFactory in _wrapperProviderFactories)
            {
                elementWrapperProvider = wrapperProviderFactory.GetProvider(wrapperProviderContext);
                if (elementWrapperProvider != null)
                {
                    var wrappingType = elementWrapperProvider.GetWrappingType(wrapperProviderContext.DeclaredType);
                    if (wrappingType != null)
                    {
                        wrappedOrDeclaredElementType = wrappingType;
                    }

                    break;
                }
            }
            
            return typeof(DelegatingEnumerable<,>).MakeGenericType(wrappedOrDeclaredElementType, declaredElementType);
        }
    }
}