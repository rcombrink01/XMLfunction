//Code By Reino Combrink 2020/12/15
//Create a Function App, and the Function App returns json array
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace XMLFunction
{
    public static class XMLConvertToJson
    {
        //We create a contract for Version 1
        [FunctionName(ApiRoutes.VersionNumber)]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestMessage request,
            ILogger log)
        {
            try
            {
                log.LogInformation("Processed an action to convert from XML to Json");
                //We convert te xml to Json and return to the user..
                XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
                var personsJsonArray = xml.Deserialize(request.Content.ReadAsStreamAsync().Result);
                return new OkObjectResult(personsJsonArray);
            }
            catch (Exception ex)
            {
                //We log the exception
                log.LogError(ex.Message.ToString());
                return new BadRequestObjectResult("Please ensure the xml is valid");
            }
        }
    }
}

