// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class EnumerableWrapperProviderFactory : IWrapperProviderFactory
    {
        private readonly IWrapperProviderFactoryProvider _wrapperProviderFactoryProvider;

        public EnumerableWrapperProviderFactory(IWrapperProviderFactoryProvider wrapperProviderFactoryProvider)
        {
            _wrapperProviderFactoryProvider = wrapperProviderFactoryProvider;
        }

        public IWrapperProvider GetProvider([NotNull] WrapperProviderContext context)
        {
            var declaredType = context.DeclaredType;

            if (context.IsSerialization)
            {
                if (declaredType != null
                    && declaredType.IsInterface()
                    && declaredType.IsGenericType())
                {
                    // check if we can get a enumerable generic type. Example: IEnumerable<SerializableError>
                    var genericType = declaredType.ExtractGenericInterface(typeof(IEnumerable<>));
                    if (genericType != null)
                    {
                        return new EnumerableWrapperProvider(
                                                        genericType,
                                                        _wrapperProviderFactoryProvider.WrapperProviderFactories,
                                                        context);
                    }
                }
            }

            return null;
        }
    }
}