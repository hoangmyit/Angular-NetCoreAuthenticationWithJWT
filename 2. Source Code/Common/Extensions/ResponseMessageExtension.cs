using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Common.Extensions
{
    public static class ResponseMessageExtension
    {
        public static HttpResponseMessage CreateResponse<T>(this HttpRequestMessage requestMessage, HttpStatusCode statusCode, T content)
        {
            return new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = new StringContent(JsonConvert.SerializeObject(content))
            };
        }
    }
}
