using System.Collections.Generic;
using System;

namespace SwiftAntE2V2.WebAPI.models
{
    public class WebAPIReturnStatus
    {
        public int rCode { get; set; }

        public Object rObj { get; set; }

        public List<ErrorMessage> rMsg { get; set; }

        public Guid reqID { get; set; }

        public string trnID { get; set; }

    }

    public class ErrorMessage
    {
        public string errorText { get; set; }

        public string errorCode { get; set; }

        public string fieldName { get; set; }

        public string fieldValue { get; set; }
    }
}
