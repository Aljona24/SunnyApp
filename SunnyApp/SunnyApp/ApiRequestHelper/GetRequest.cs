using SunnyApp.ApiRequestHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SunnyApp.ApiRequestHelper
{
    public class GetRequest
    {
        private string _endpoint;

        public GetRequest(string baseUrl)
        {
            BaseUrl = baseUrl;
        }        

        protected string BaseUrl { get; }

        public GetRequest SetPathPart(string path)
        {
            _endpoint = $"/{path}";
            return this;
        }

        public GetRequest AddQueryStringParameter(string paramName, string paramValue)
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

        public virtual async Task<T> GetAsync<T>()
        {
            using (var httpClient = new HttpClient())
            {
                return await GetAsyncInternal<T>(httpClient);
            }
        }

        protected async Task<T> GetAsyncInternal<T>(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(BaseUrl);
            var response = await httpClient.GetAsync(_endpoint);
            if (!response.IsSuccessStatusCode)
            {
                var jsonError = await response.Content.ReadAsStringAsync();
                var serverErrorResponse = JsonConvert.DeserializeObject<ServerErrorResponseModel>(jsonError);
                throw new HttpException(serverErrorResponse);
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

