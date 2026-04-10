using AzureFunc.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunc;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("OnSalesUploadWriteToQueue")]
 
    [QueueOutput("SalesRequestOutBound", Connection = "AzureWebJobsStorage")]
    public async Task<SalesRequest> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        SalesRequest? data = JsonConvert.DeserializeObject<SalesRequest>(requestBody);
        if (data != null && string.IsNullOrEmpty(data.Id))
        {
            data.Id = Guid.NewGuid().ToString();
        }

        _logger.LogInformation($"Processed request with ID: {data?.Id}");
        return data ?? new SalesRequest();
    }
}