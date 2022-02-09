using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Func.LoadSettings.Json.Options;
using Microsoft.Extensions.Options;

namespace Company.Function
{
    public class BasicHttpFunc
    {
        private readonly MyServerOptions _myServerOptions;

        public BasicHttpFunc(IOptions<MyServerOptions> myServerOptions)
        {
            _myServerOptions = myServerOptions?.Value ?? throw new ArgumentNullException(nameof(myServerOptions));
        }

        [FunctionName("basic-http-func")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(_myServerOptions.ApiUrl);
        }
    }
}
