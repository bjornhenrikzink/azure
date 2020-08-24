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

    // Create json object
    var jsonObj = new {msg = "Hello", name = name};

    // Return json
    return new JsonResult(JsonConvert.SerializeObject(jsonObj));
}
