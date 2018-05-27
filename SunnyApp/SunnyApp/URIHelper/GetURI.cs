using SunnyApp.URIHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SunnyApp.URIHelper
{
    public class GetURI
    {
        private string _endpoint;

        public GetURI(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        protected string BaseUrl { get; }

        public GetURI SetPathPart(string path)
        {
            _endpoint = $"/{path}/";
            return this;
        }

        public GetURI AddQueryStringParameter(string paramName, string paramValue)
        {
            AddQueryStringParameterInternal(paramName, paramValue);
            return this;
        }

        private void AddQueryStringParameterInternal(string paramName, string paramValue)
        {
            var isFirstParam = !_endpoint.Contains("?");
            _endpoint += isFirstParam ? "?" : "&";
            _endpoint += $"{paramName}={paramValue}";
        }

        public async Task<T> GetAsync<T>()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var response = await httpClient.GetAsync(_endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpException();
                }

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
