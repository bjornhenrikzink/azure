#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    // Query
    string name = req.Query["name"];

    // Input   
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);

    // Query or Input name?
    name = name ?? data?.name;
    name = name ?? "Björn-Henrik Zink";

    // Create json object
    var jsonObj = new {name = name,domain = "Customer Fulfilment",productarea = "Digital Core", productteam = ""};

    log.LogInformation("C# HTTP trigger function returning a json response");

    // Return json
    return new JsonResult(jsonObj);
}

