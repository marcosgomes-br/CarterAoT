using Core.DTOs;
using Core.Models;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class ServiceBase
    {
        public static JsonSerializerOptions options;

        public static HttpRequestMessage ConnectService(string url, HttpMethod httpMethod) {

            var httpRequestMessage = new HttpRequestMessage(httpMethod, url)
            {
                Headers =
            {
                    { HeaderNames.Accept, "application/json; charset=UTF-8" }
            }
            };

            return httpRequestMessage;
        }


        
    }
}
