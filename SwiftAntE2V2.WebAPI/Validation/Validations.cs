using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SwiftAntE2V2.WebAPI.Validation
{
    public class Validations
    {
        public class Validator<T, T2, T3, T4, T5>
        {
            private readonly T _value;
            private readonly T2 _value2;
            private readonly T3 _value3;
            private readonly T4 _fieldName;
            private readonly T5 _fieldValue;
            public string _errorText;
            public string fieldName;
            public string fieldValue;
            private readonly HashSet<string> _validationErrors;
            public Validator(T value, T2 value2, T3 value3, T4 value4, T5 value5)
            {
                _value = value;
                _value2 = value2;
                _value3 = value3;
                _fieldName = value4;
                _fieldValue = value5;
                _validationErrors = new HashSet<string>();
            }
            public ValidationResult GetResult() =>
                new ValidationResult(_validationErrors, HasErrors, _errorText, fieldName, fieldValue);
            //public RootObject GetResult() => new RootObject(
            //    new Error())
            private bool HasErrors => _validationErrors.Any();

            public Validator<T, T2, T3, T4, T5> AddRule(Func<T, T2, bool> rule, string message, string errorCode, string fieldName, string filedValue)
            {
                try
                {

                    if (!rule(_value, _value2))
                        _validationErrors.Add(message + ";" + errorCode + ";" + fieldName + ";" + filedValue);
                    return this;

                }
                catch (Exception)
                {
                    return this;

                }
                //  return this;

            }

            public Validator<T, T2, T3, T4, T5> AddstringEmptyRule(Func<T, bool> rule, string message, string errorCode, string fieldname, string filedValue)
            {
                try
                {
                    if (!rule(_value))
                        _validationErrors.Add(message + ";" + errorCode + ";" + fieldname + ";" + filedValue);
                    // _errorText = message;

                    return this;
                }
                catch (Exception)
                {
                    return this;

                }
                // return this;
            }

            public Validator<T, T2, T3, T4, T5> AddNewRule(Func<T, T2, T3, bool> rule, string message)
            {
                try
                {
                    if (!rule(_value, _value2, _value3))
                        _validationErrors.Add(message);
                    return this;

                }
                catch (Exception)
                {
                    return this;

                }
                //  return this;

            }

        }



        public class ValidationResult
        {
            public string errorCode { get; }
            public string errorText { get; }
            public string fieldName { get; set; }
            public string fieldValue { get; set; }


            public ICollection<string> ValidationErrors { get; }

            public bool HasErrors { get; }
            public ValidationResult(ICollection<string> validationErrors, bool hasErrors, string ErrorText, string fName, string fValue)
            {
                // errorCode = fieldName;
                fieldName = fName;
                fieldValue = fValue;
                ValidationErrors = validationErrors;
                HasErrors = hasErrors;
                if (validationErrors.Count > 0)
                {
                    errorText = validationErrors.First();
                }

            }

            public string Message() => string.Join(" ", ValidationErrors.Select(error => $"{error}"));
        }

        public class Error
        {
            public string errorCode { get; set; }
            public string errorText { get; set; }

        }
        public class RootObject
        {
            public List<Error> Error { get; set; }
        }
        public bool StringNotEmpty(string s, int s2) => !string.IsNullOrEmpty(s);
        public bool StringEmpty1(string s) => !string.IsNullOrEmpty(s);
        public bool StringEmpty(string s)
        {
            try
            {
                if (!string.IsNullOrEmpty(s))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool StringisEmpty(string s, string CertificateClassificationID)
        {
            if (CertificateClassificationID == "5")
            {
                return true;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(s))
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public bool isValidEmail(string inputEmail, int s)
        {
            if (!string.IsNullOrEmpty(inputEmail))
            {
                try
                {
                    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                      @".)+))([a-zA-Z]{2,12}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(strRegex);
                    if (re.IsMatch(inputEmail))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }


        }

        //public bool isValidNumber(string inputEmail, int s)
        //{
        //    if (!string.IsNullOrEmpty(inputEmail))
        //    {
        //        try
        //        {
        //            string strRegex = @"^\d{4}$";
        //            Regex re = new Regex(strRegex);
        //            if (re.IsMatch(inputEmail))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }


        //}

        public bool isValidPassword(string inputPassword, int s)
        {
            if (!string.IsNullOrEmpty(inputPassword))
            {
                try
                {
                    string strRegex = "^(?=.*[0-9])"
                                        + "(?=.*[a-z])(?=.*[A-Z])"
                                        + "(?=.*[@#$%^&+=])"
                                        + "(?=\\S+$).{8,100}$";

                    Regex regex = new Regex(strRegex);

                    if (regex.IsMatch(inputPassword))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool isValidMobileNo(string inputMonileNo, int s)
        {
            if (!string.IsNullOrEmpty(inputMonileNo))
            {
                try
                {
                    string reg = "^[6-9]{1}[0-9]{9}$";

                    Regex regex = new Regex(reg);

                    if (regex.IsMatch(inputMonileNo))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool isValidNumber(string inputEmail, int s)
        {
            if (!string.IsNullOrEmpty(inputEmail))
            {
                try
                {
                    Convert.ToInt32(inputEmail);
                    return true;

                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }


        }

        public bool isInsuredPIN(string input, int s)
        {
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    string strRegex = @"^[a-zA-Z]{1}[0-9]{9}[a-zA-Z]{1}$";
                    Regex re = new Regex(strRegex);
                    if (re.IsMatch(input))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsEither(string para1, string para2)
        {

            if (!string.IsNullOrEmpty(para1))
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(para2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MaxLength(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput > length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public bool IsVaildPhoneNo(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput == 9)
                {
                    try
                    {
                        Convert.ToInt64(Value);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }
                else
                {
                    return false;

                }
            }
            else
            {
                return true;
            }
        }
        public bool IsVaildCRAMemberID(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput > 5 && lengthoutput < 9)
                {
                    try
                    {
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }
                else
                {
                    return false;

                }
            }
            else
            {
                return true;
            }
        }
        public bool IsVaildDate(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput == 11)
                {
                    try
                    {
                        Convert.ToDateTime(Value);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }

                }
                else
                {
                    return false;

                }
            }
            else
            {
                return true;
            }
        }

        public bool IsVaildDateOrDateTime(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput == 17)
                {
                    try
                    {
                        Convert.ToDateTime(Value);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                if (lengthoutput == 11)
                {
                    try
                    {
                        Convert.ToDateTime(Value);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool IsVaildDateTime(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput == 17)
                {
                    try
                    {
                        Convert.ToDateTime(Value);
                        return true;
                    }
                    catch (Exception)
                    {

                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool MinLength(string Value, int length)
        {
            if (!string.IsNullOrEmpty(Value))
            {
                int lengthoutput = Value.Length;
                if (lengthoutput < length)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public bool isValidGUID(string inputGUID, int s)
        {
            if (!string.IsNullOrEmpty(inputGUID))
            {
                try
                {
                    new Guid(inputGUID);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool isValidDecimal(string inputDecimal, int s)
        {
            if (!string.IsNullOrEmpty(inputDecimal))
            {
                try
                {
                    Convert.ToDecimal(inputDecimal);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool isValidInt(string inputDecimal, int s)
        {
            if (!string.IsNullOrEmpty(inputDecimal))
            {
                try
                {
                    Convert.ToInt32(inputDecimal);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool isValidBoolean(string inputDecimal, int s)
        {
            if (!string.IsNullOrEmpty(inputDecimal))
            {
                try
                {
                    Convert.ToBoolean(inputDecimal);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public bool isValidRegex(string inputRegex, int s)
        {
            if (!string.IsNullOrEmpty(inputRegex))
            {
                try
                {
                    var regex = new Regex(@"^[0-9]{1,18}([.][0-9]{1,10})?$");
                    if (regex.IsMatch(inputRegex))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
