﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.Hosting;

namespace RequestServicesWebSite
{
    public class RequestIdService
    {
        // This service can only be instantiated by a request-scoped container
        public RequestIdService(IServiceProvider services, IHttpContextAccessor contextAccessor)
        {
            if (contextAccessor.Value.RequestServices != services)
            {
                throw new InvalidOperationException();
            }
        }

        public string RequestId { get; set; }
    }
}