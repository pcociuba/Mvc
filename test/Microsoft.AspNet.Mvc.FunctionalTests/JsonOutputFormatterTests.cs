﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.AspNet.Mvc.FunctionalTests
{
    public class JsonOutputFormatterTests
    {
        private readonly IServiceProvider _provider = TestHelper.CreateServices("FormatterWebSite");
        private readonly Action<IApplicationBuilder> _app = new FormatterWebSite.Startup().Configure;

        [Fact]
        public async Task JsonOutputFormatter_ReturnsIndentedJson()
        {
            // Arrange
            var user = new FormatterWebSite.User()
            {
                Id = 1,
                Alias = "john",
                description = "Administrator",
                Designation = "Administrator",
                Name = "John Williams"
            };

            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.Formatting = Formatting.Indented;
            var expectedBody = JsonConvert.SerializeObject(user, serializerSettings);

            var server = TestServer.Create(_provider, _app);
            var client = server.CreateClient();

            // Act
            var response = await client.GetAsync("http://localhost/JsonFormatter/ReturnsIndentedJson");

            // Assert
            var actualBody = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedBody, actualBody);
        }

        //[Theory]
        //[InlineData("http://localhost/SerializableError/CreateEmployee",
        //    "application/json",
        //    "{\"employee.Id\":[\"" + sampleIntError + "\"]," +
        //    "\"employee.Name\":" +
        //    "[\"" + sampleStringError + "\"]}")]
        //public async Task SerializableErrorIsReturnedInExpectedFormat(string url, string acceptHeader, string output)
        //{
        //    // Arrange
        //    var server = TestServer.Create(_provider, _app);
        //    var client = server.CreateClient();

        //    var input = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
        //        "<Employee xmlns=\"http://schemas.datacontract.org/2004/07/XmlFormattersWebSite\">" +
        //        "<Id>2</Id><Name>foo</Name></Employee>";
        //    var request = new HttpRequestMessage(HttpMethod.Post, url);
        //    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(acceptHeader));
        //    request.Content = new StringContent(input, Encoding.UTF8, "application/xml");

        //    // Act
        //    var response = await client.SendAsync(request);

        //    // Assert
        //    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        //    Assert.Equal(output, await response.Content.ReadAsStringAsync());
        //}
    }
}