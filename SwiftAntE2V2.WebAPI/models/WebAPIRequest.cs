using System;

namespace SwiftAntE2V2.WebAPI.models
{
    public class WebAPIRequest
    {
        public dynamic dPO { get; set; }

        public string iPAddress { get; set; }

        public Guid requestID { get; set; }

        public string applicationID { get; set; }

        public string applicationName { get; set; }

        public string requestURL { get; set; }

    }
}
