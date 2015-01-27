// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class SerializableErrorWrapperProviderFactory : IWrapperProviderFactory
    {
        public IWrapperProvider GetProvider([NotNull] WrapperProviderContext context)
        {
            if (context.DeclaredType == typeof(SerializableError))
            {
                return new SerializableErrorWrapperProvider(context);
            }

            return null;
        }
    }
}