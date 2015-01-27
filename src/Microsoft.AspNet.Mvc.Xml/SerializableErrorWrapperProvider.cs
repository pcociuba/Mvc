// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Mvc;

namespace Microsoft.AspNet.Mvc.Xml
{
    public class SerializableErrorWrapperProvider : IWrapperProvider
    {
        private readonly WrapperProviderContext _context;

        public SerializableErrorWrapperProvider([NotNull] WrapperProviderContext context)
        {
            _context = context;
        }

        public Type WrappingType
        {
            get
            {
                return typeof(SerializableErrorWrapper);
            }
        }

        public object Wrap(object original)
        {
            var error = original as SerializableError;
            if (error == null)
            {
                return original;
            }

            return new SerializableErrorWrapper(error);
        }
    }
}