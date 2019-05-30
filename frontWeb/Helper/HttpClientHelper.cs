using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace frontWeb.Service
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            var MyHttpClient = new HttpClient();
            return MyHttpClient;
        }
    }
}

