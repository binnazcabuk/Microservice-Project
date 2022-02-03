using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Shared.BaseResponses
{
    public enum BaseErrorCode
    {
        ecNoError = 0,
        ecInvalidParameter = 1000,
        ecUknownError = 1100,
        ecAuthFailed = -1,
        ecUserMessage = 1200,
        ecUnauthorized = 900
    };

    public static class BaseErrorCodeExtension
    {
        public static BaseResponse CreateResponse(this BaseErrorCode code, string message = "") => new BaseResponse(new BaseResponseError(code, message));

        public static BaseResponseError CreateError(this BaseErrorCode code, string message = "") => new BaseResponseError(code, message);
    }

    [DataContract]
    public class BaseResponseError
    {
        public BaseResponseError(BaseErrorCode code = BaseErrorCode.ecNoError, string message = "")
        {
            this.code = code;
            this.message = message;
        }

        [DataMember]
        public BaseErrorCode code { get; private set; }

        [DataMember]
        public string message { get; private set; }
    }
}
