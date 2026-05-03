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
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("Triggered - Author: Sanke Wadbudhe");

        var name = req.Query["name"].ToString();
        if (string.IsNullOrEmpty(name)) name = "World";

        return new OkObjectResult(new
        {
            message   = $"Hello, {name}! This is Sanke Wadbudhe's Azure Function.",
            author    = "Sanke Wadbudhe",
            timestamp = DateTime.UtcNow.ToString("o"),
            status    = "success"
        });
    }
}
