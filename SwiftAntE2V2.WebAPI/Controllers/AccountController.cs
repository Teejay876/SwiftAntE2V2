using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SwiftAntE2V2.WebAPI.models;
using System.Collections.Generic;
using System.Collections;
using SwiftAntE2V2.WebAPI.Validation;
using System;
using SwiftAntE2V2.WebAPI.Resoures;

namespace SwiftAntE2V2.WebAPI.Controllers
{
    [Route("api/v1/Account")]
    [ApiController]
    public class AccountController : GenericController
    {
        private readonly IConfiguration _configuration;
        private readonly AccountValidation _accountValidation;
        public AccountController(IConfiguration configuration)
        {
            _configuration= configuration;
            _accountValidation= new AccountValidation();   
        }
       /// <summary>
       /// CreateBy Sethu Kannan
       /// CreatedOn 22-Dec-2022
       /// Tickket N0 347198
       /// </summary>
       /// <returns></returns>

        [HttpPost]
        [Route("Login")]
        public WebAPIReturnStatus Login()
        {
            WebAPIReturnStatus ReturnStatus = new WebAPIReturnStatus();
            List<ErrorMessage> errorMessages = new List<ErrorMessage>();
            Hashtable hashtable = new Hashtable();
            try
            {
                //calling request body from postman
                WebAPIRequest webAPIRequest = GetRequest(_configuration);
               
                //calling Account validation
                _accountValidation.AccountLogin(webAPIRequest, out errorMessages);

                try
                {
                    if (errorMessages != null)
                    {
                        //If input validation failed Return error
                        ReturnStatus = new WebAPIReturnStatus { rCode = 502, reqID = webAPIRequest.requestID, rMsg = errorMessages };
                        return ReturnStatus;
                    }
                    errorMessages = new List<ErrorMessage>();
                    //If the email and password match correctly
                    errorMessages.Add(new ErrorMessage { errorCode = ErrorCode.SUCCESS, errorText = ErrorCodeMessage.SUCCESS });
                    ReturnStatus = new WebAPIReturnStatus { rCode = 200, reqID = webAPIRequest.requestID, rMsg = errorMessages, rObj = hashtable };
                }
                catch (Exception)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                //If the THE jSON BODY IS INVALID
                errorMessages.Add(new ErrorMessage { errorCode = ErrorCode.ER0006, errorText = ErrorCodeMessage.ER0006 });
                ReturnStatus = new WebAPIReturnStatus { rCode = 200, reqID = Guid.NewGuid(), rMsg = errorMessages, rObj = hashtable }; 
            }
            return ReturnStatus;
        }
    }
}
