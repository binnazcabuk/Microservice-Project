using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T data { get; private set; }

        [JsonIgnore]
        public int statusCode { get;private set; }
        [JsonIgnore]
        public bool isSuccess { get;private set; }

        public List<string> errors { get; set; }

        //static factory method
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { data=data, statusCode=statusCode, isSuccess=true };
        }

        public static ResponseDto<T>Success(int statusCode)
        {
            return new ResponseDto<T> { data=default(T), statusCode=statusCode, isSuccess=true };
        }

        public static ResponseDto<T>Fail(List<string>errors,int statusCode)
        {
            return new ResponseDto<T>
            {
                errors=errors,
                statusCode=statusCode,
                isSuccess=false
            };
        }

        public  static ResponseDto<T>Fail(string errors,int statusCode)
        {
            return new ResponseDto<T> { errors=new List<string>() { errors }, statusCode=statusCode, isSuccess=false };
        }
    }
}
