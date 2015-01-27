// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Net.Http.Headers;

namespace ConnegWebSite
{
    [Route("ObjectResultMatchAll/[Action]")]
    public class ObjectResultMatchAllController : Controller
    {
        public IActionResult All()
        {
            var result = new ObjectResult("All");
            result.ContentTypes.Add(MediaTypeHeaderValue.Parse("*/*"));
            return result;
        }

        public IActionResult AllTypes()
        {
            var result = new ObjectResult("All");
            result.ContentTypes.Add(MediaTypeHeaderValue.Parse("*/json"));
            return result;
        }

        public IActionResult AllSubTypes()
        {
            var result = new ObjectResult("All");
            result.ContentTypes.Add(MediaTypeHeaderValue.Parse("application/*"));
            return result;
        }
    }
}