using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace StaticWebAppsEndToEndTesting.GetRoles
{
    public class GetRoles
    {
        [Function("GetRoles")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            string requestBody = new StreamReader(req.Body).ReadToEnd(); 
            var response = req.CreateResponse(HttpStatusCode.OK);
            var roles = new List<string>
            {
                "customRole",
                requestBody
            };
            var dict = new Dictionary<string, List<string>>
            {
                ["roles"] = roles
            };
            string message = JsonConvert.SerializeObject(dict);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(message);
            return response;
        }
    }
}
