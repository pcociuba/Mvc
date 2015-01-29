// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Xunit;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class DefaultWrapperProviderFactoryProviderTest
    {
        [Fact]
        public void Creates_DefaultWrapperProviderFactories()
        {
            // Arrange and Act
            var factoryProvider = new DefaultWrapperProviderFactoryProvider();

            // Assert
            var wrapperProviderFactories = factoryProvider.WrapperProviderFactories;
            Assert.NotNull(wrapperProviderFactories);
            Assert.Equal(2, wrapperProviderFactories.Count);
            Assert.IsType<EnumerableWrapperProviderFactory>(wrapperProviderFactories[0]);
            Assert.IsType<SerializableErrorWrapperProviderFactory>(wrapperProviderFactories[1]);
        }
    }
}