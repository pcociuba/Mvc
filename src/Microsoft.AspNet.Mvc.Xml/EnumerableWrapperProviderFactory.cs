// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc.Xml
{
    /// <summary>
    /// Creates an <see cref="EnumerableWrapperProvider"/> for interface types implementing the 
    /// <see cref="IEnumerable{T}"/> type.
    /// </summary>
    public class EnumerableWrapperProviderFactory : IWrapperProviderFactory
    {
        private readonly IWrapperProviderFactoryProvider _wrapperProviderFactoryProvider;

        /// <summary>
        /// Initializes an <see cref="EnumerableWrapperProviderFactory"/> with the  
        /// </summary>
        /// <param name="wrapperProviderFactoryProvider"></param>
        public EnumerableWrapperProviderFactory(IWrapperProviderFactoryProvider wrapperProviderFactoryProvider)
        {
            _wrapperProviderFactoryProvider = wrapperProviderFactoryProvider;
        }

        /// <summary>
        /// Gets an <see cref="EnumerableWrapperProvider"/> for the provided context.
        /// </summary>
        /// <param name="context">The <see cref="WrapperProviderContext"/>.</param>
        /// <returns></returns>
        /// <remarks>
        /// 
        /// </remarks>
        public IWrapperProvider GetProvider([NotNull] WrapperProviderContext context)
        {
            if (context.IsSerialization)
            {
                var declaredType = context.DeclaredType;

                if (declaredType != null && declaredType.IsInterface() && declaredType.IsGenericType())
                {
                    // check if we can get a enumerable generic type. Example: IEnumerable<SerializableError>
                    var enumerableOfT = declaredType.ExtractGenericInterface(typeof(IEnumerable<>));
                    if (enumerableOfT != null)
                    {
                        return new EnumerableWrapperProvider(
                                                        enumerableOfT,
                                                        _wrapperProviderFactoryProvider.WrapperProviderFactories,
                                                        context);
                    }
                }
            }

            return null;
        }
    }
}