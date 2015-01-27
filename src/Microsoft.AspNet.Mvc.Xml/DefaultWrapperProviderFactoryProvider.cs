// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class DefaultWrapperProviderFactoryProvider : IWrapperProviderFactoryProvider
    {
        public DefaultWrapperProviderFactoryProvider()
        {
            var providerFactories = new List<IWrapperProviderFactory>();
            providerFactories.Add(new EnumerableWrapperProviderFactory(this));
            providerFactories.Add(new SerializableErrorWrapperProviderFactory());

            WrapperProviderFactories = providerFactories;
        }

        public IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    }
}