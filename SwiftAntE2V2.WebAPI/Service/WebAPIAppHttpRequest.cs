using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;

namespace SwiftAntE2V2.WebAPI.Service
{
    public static class WebAPIAppHttpRequest
    {
        public static string GetRawBodyString(this HttpRequest request, Encoding encoding = null)
        {
            using (StreamReader reader = new StreamReader(request.Body, encoding))
            {
                return reader.ReadToEndAsync().Result;
            }
        }
    }
}

