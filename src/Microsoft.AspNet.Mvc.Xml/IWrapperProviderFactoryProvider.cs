// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Microsoft.AspNet.Mvc.Xml
{
    /// <summary>
    /// Defines an interface for getting list of wrapper provider factories.
    /// </summary>
    public interface IWrapperProviderFactoryProvider
    {
        IList<IWrapperProviderFactory> WrapperProviderFactories { get; }
    }
}