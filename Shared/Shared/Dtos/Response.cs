using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.Dtos
{
    public class Response<T>
    {
        public T data { get; private set; }

        [JsonIgnore]
        public int statusCode { get;private set; }
        [JsonIgnore]
        public bool isSuccess { get;private set; }

        public List<string> errors { get; set; }

        //static factory method
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { data=data, statusCode=statusCode, isSuccess=true };
        }

        public static Response<T>Success(int statusCode)
        {
            return new Response<T> { data=default(T), statusCode=statusCode, isSuccess=true };
        }

        public static Response<T>Fail(List<string>errors,int statusCode)
        {
            return new Response<T>
            {
                errors=errors,
                statusCode=statusCode,
                isSuccess=false
            };
        }

        public  static Response<T>Fail(string errors,int statusCode)
        {
            return new Response<T> { errors=new List<string>() { errors }, statusCode=statusCode, isSuccess=false };
        }
    }
}
