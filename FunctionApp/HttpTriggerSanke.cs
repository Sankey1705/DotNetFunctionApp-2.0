using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FunctionApp;

public class HttpTriggerSanke
{
    private readonly ILogger<HttpTriggerSanke> _logger;

    public HttpTriggerSanke(ILogger<HttpTriggerSanke> logger)
    {
        _logger = logger;
    }

    [Function("HttpTriggerSanke")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}
