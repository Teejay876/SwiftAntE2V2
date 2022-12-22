using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwiftAntE2V2.WebAPI.Service;
using System;
using SwiftAntE2V2.WebAPI.models;
using Newtonsoft.Json.Linq;

namespace SwiftAntE2V2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        public WebAPIRequest GetRequest(IConfiguration configuration)
        {
            WebAPIRequest webAPIRequest = new WebAPIRequest();
            try
            {
                
                webAPIRequest.requestID = Guid.NewGuid();
                string Json = Request.GetRawBodyString();
                if (!string.IsNullOrEmpty(Json))
                {
                    webAPIRequest.dPO = JObject.Parse(Json);
                }

            }
            catch (Exception)
            {
                
               
            }

            return webAPIRequest;
        }
    }
}
