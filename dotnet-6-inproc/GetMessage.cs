using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StaticWebAppsEndToEndTesting.GetMessage
{
    public static class GetMessage
    {
        [FunctionName("GetMessage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ExecutionContext context,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request! :) ");
            string message = File.ReadAllText(context.FunctionAppDirectory + "/content.txt");
            var environmentVariables = Environment.GetEnvironmentVariables();
            message = JsonConvert.SerializeObject(environmentVariables);
            return new OkObjectResult(message);
        }
    }
}
