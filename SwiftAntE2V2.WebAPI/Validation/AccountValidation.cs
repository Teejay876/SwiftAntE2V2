
using SwiftAntE2V2.WebAPI.models;
using System.Collections.Generic;
using System.Linq;
using System;
using SwiftAntE2V2.WebAPI.Validation;
using SwiftAntE2V2.WebAPI.Resoures;



namespace SwiftAntE2V2.WebAPI.Validation
{
    public class AccountValidation : Validations
    {
        public bool AccountLogin(WebAPIRequest webAPIRequest, out List<ErrorMessage> errorMessage)
        {
            List<ErrorMessage> errorMessages = new List<ErrorMessage>();

            if (!string.IsNullOrEmpty(Convert.ToString(webAPIRequest.dPO)))
            {

                string email = Convert.ToString(webAPIRequest.dPO.email);
                string password = Convert.ToString(webAPIRequest.dPO.password);

                try
                {
                    ValidationResult[] results = new[]
                    {
                        //Email is required
                           new Validator<string,int,string,string ,string>(email,0,"email","email", ErrorCode.ER0001)
                        .AddstringEmptyRule(StringEmpty, ErrorCode.ER0001, ErrorCodeMessage.ER0001,"email",email)
                        .GetResult(),
                        //Email is not a valid
                            new Validator<string,int,string,string ,string>(email,0,"email","email", ErrorCode.ER0003)
                        .AddRule(isValidEmail, ErrorCode.ER0003, ErrorCodeMessage.ER0003,"email",email)
                        .GetResult(),

                        //Password is required
                        new Validator<string,int,string,string ,string>(password,0,"password","password", ErrorCode.ER0002)
                        .AddstringEmptyRule(StringEmpty, ErrorCode.ER0002, ErrorCodeMessage.ER0002,"password",password)
                        .GetResult(),

                        //Password is not a valid
                        new Validator<string,int,string,string ,string>(password,0,"password","password", ErrorCode.ER0004)
                        .AddRule(isValidPassword, ErrorCode.ER0004, ErrorCodeMessage.ER0004,"password",password)
                        .GetResult(),


                    }
                    .Where(r => r.HasErrors)
                    .ToArray();
                    if (results.Any())
                    {
                        foreach (var item in results.Select(r => r.Message()))
                        {
                            errorMessages.Add(new ErrorMessage
                            {
                                errorCode = item.Split(";")[0],
                                errorText = item.Split(";")[1],
                                fieldName = item.Split(";")[2],
                                fieldValue = item.Split(";")[3],
                            });
                        }
                        // results = , new { Name = person.Name; Family = person.Family})
                        errorMessage = errorMessages;
                        return false;
                    }
                    else
                    {
                        errorMessage = null;
                        return true;
                    }

                }
                catch (Exception)
                {
                    errorMessage = null;
                    return false;
                }
            }
            else
            {

                //Email is required
                errorMessages.Add(new ErrorMessage
                {
                    errorText = ErrorCodeMessage.ER0001,
                    errorCode = ErrorCode.ER0001,
                    fieldName = "email"
                });

                //Password is required
                errorMessages.Add(new ErrorMessage
                {
                    errorText = ErrorCodeMessage.ER0002,
                    errorCode = ErrorCode.ER0002,
                    fieldName = "password"
                });

                errorMessage = errorMessages;
            }
            return false;
        }
    }
}
