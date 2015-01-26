﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNet.Mvc.Core;
using Microsoft.AspNet.Mvc.Internal;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Routing;

namespace Microsoft.AspNet.Mvc
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RemoteAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _additionalFields = string.Empty;
        private string[] _additionalFieldsSplit = new string[0];

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// Intended for subclasses that support URL generation with no route, action, or controller names.
        /// </remarks>
        protected RemoteAttribute()
            : base(Resources.RemoteAttribute_RemoteValidationFailed)
        {
            RouteData = new RouteValueDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteAttribute"/> class.
        /// </summary>
        /// <param name="routeName">
        /// The route name used when generating the URL where client should send a validation request.
        /// </param>
        /// <remarks>
        /// Finds the <paramref name="routeName"/> in any area of the application.
        /// </remarks>
        public RemoteAttribute(string routeName)
            : this()
        {
            if (string.IsNullOrWhiteSpace(routeName))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, "routeName");
            }

            RouteName = routeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteAttribute"/> class.
        /// </summary>
        /// <param name="action">
        /// The action name used when generating the URL where client should send a validation request.
        /// </param>
        /// <param name="controller">
        /// The controller name used when generating the URL where client should send a validation request.
        /// </param>
        /// <remarks>
        /// Finds the <paramref name="controller"/> in the current area.
        /// </remarks>
        public RemoteAttribute(string action, string controller)
            : this()
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, "action");
            }
            if (string.IsNullOrWhiteSpace(controller))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, "controller");
            }

            RouteData["controller"] = controller;
            RouteData["action"] = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteAttribute"/> class.
        /// </summary>
        /// <param name="action">The action name.</param>
        /// <param name="controller">The controller name.</param>
        /// <param name="areaName">
        /// The name of the area containing the <paramref name="controller"/>. If <c>null</c>, finds the
        /// <paramref name="controller"/> in the root area.
        /// </param>
        /// <remarks>
        /// Use the <see cref="RemoteAttribute(string, string)"/> overload find the <paramref name="controller"/> in
        /// the current area. Or explicitly pass the current area's name as the <paramref name="areaName"/> argument to
        /// this overload.
        /// </remarks>
        public RemoteAttribute(string action, string controller, string areaName)
            : this(action, controller)
        {
            RouteData["area"] = areaName;
        }

        /// <summary>
        /// Gets or sets the HTTP method (<c>"Get"</c> or <c>"Post"</c>) client should use when sending a validation
        /// request.
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the comma-separated names of fields the client should include in a validation request.
        /// </summary>
        public string AdditionalFields
        {
            get { return _additionalFields; }
            set
            {
                _additionalFields = value ?? string.Empty;
                _additionalFieldsSplit = StringHelper.SplitString(value).AsArray();
            }
        }

        /// <summary>
        /// Gets the <see cref="RouteValueDictionary"/> used when generating the URL where client should send a
        /// validation request.
        /// </summary>
        protected RouteValueDictionary RouteData { get; }

        /// <summary>
        /// Gets or sets the route name used when generating the URL where client should send a validation request.
        /// </summary>
        protected string RouteName { get; set; }

        /// <summary>
        /// Formats <paramref name="property"/> and <see cref="AdditionalFields"/> for use in generated HTML.
        /// </summary>
        /// <param name="property">
        /// Name of the property associated with this <see cref="RemoteAttribute"/> instance.
        /// </param>
        /// <returns>Comma-separated names of fields the client should include in a validation request.</returns>
        /// <remarks>
        /// Excludes any whitespace from <see cref="AdditionalFields"/> in the return value.
        /// Prefixes each field name in the return value with <c>"*."</c>.
        /// </remarks>
        public string FormatAdditionalFieldsForClientValidation(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, "property");
            }

            var delimitedAdditionalFields = FormatPropertyForClientValidation(property);
            foreach (var field in _additionalFieldsSplit)
            {
                delimitedAdditionalFields += "," + FormatPropertyForClientValidation(field);
            }

            return delimitedAdditionalFields;
        }

        /// <summary>
        /// Formats <paramref name="property"/> for use in generated HTML.
        /// </summary>
        /// <param name="property">One field name the client should include in a validation request.</param>
        /// <returns>Name of a field the client should include in a validation request.</returns>
        /// <remarks>Returns <paramref name="property"/> with a <c>"*."</c> prefix.</remarks>
        public static string FormatPropertyForClientValidation(string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, "property");
            }

            return "*." + property;
        }

        /// <summary>
        /// Returns the URL where the client should send a validation request.
        /// </summary>
        /// <param name="context">The <see cref="MvcClientModelValidationContext"/> used to generate the URL.</param>
        /// <returns>The URL where the client should send a validation request.</returns>
        protected virtual string GetUrl([NotNull] MvcClientModelValidationContext context)
        {
            var url = context.UrlHelper.RouteUrl(
                routeName: RouteName,
                values: RouteData,
                protocol: null,
                host: null,
                fragment: null);
            if (url == null)
            {
                throw new InvalidOperationException(Resources.RemoteAttribute_NoUrlFound);
            }

            return url;
        }

        /// <inheritdoc />
        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }

        /// <inheritdoc />
        public override bool IsValid(object value)
        {
            return true;
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentException">
        /// Thrown if provided <paramref name="context"/> is not a <see cref="MvcClientModelValidationContext"/>
        /// instance.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if unable to generate a target URL for a validation request.
        /// </exception>
        public virtual IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            [NotNull] ClientModelValidationContext context)
        {
            var mvcContext = context as MvcClientModelValidationContext;
            if (mvcContext == null)
            {
                var message = Resources.FormatArgumentUnexpectedType(
                    context.GetType().FullName,
                    typeof(MvcClientModelValidationContext).FullName);
                throw new ArgumentException(message, nameof(context));
            }

            var metadata = context.ModelMetadata;
            var rule = new ModelClientValidationRemoteRule(
                FormatErrorMessage(metadata.GetDisplayName()),
                GetUrl(mvcContext),
                HttpMethod,
                FormatAdditionalFieldsForClientValidation(metadata.PropertyName));

            return new[] { rule };
        }
    }
}