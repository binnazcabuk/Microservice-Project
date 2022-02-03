using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.BaseResponses
{
    public class BaseResponse
    {
        public BaseResponse() => error = BaseErrorCode.ecNoError.CreateError();

        public BaseResponse(BaseErrorCode code, string message) => error = code.CreateError(message);

        public BaseResponse(BaseResponseError error) => this.error = error;

        public BaseResponseError error { get; set; }
    }
    public class BaseResponse<T> : BaseResponse
    {
        public T data { get; set; }

        public BaseResponse() : base() => data = default(T);

        public BaseResponse(T data) : base() => this.data = data;
    }
}
