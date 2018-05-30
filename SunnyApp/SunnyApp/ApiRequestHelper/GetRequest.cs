﻿using SunnyApp.ApiRequestHelper.Exceptions;
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

            HttpResponseMessage response;

            try
            {
                response = await httpClient.GetAsync(_endpoint);
            }
            catch (HttpRequestException ex)
            {
                //TODO: throw HttpEXception
                throw new HttpException();
            } 

            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var serverErrorResponse = JsonConvert.DeserializeObject<ServerErrorResponseModel>(json);
                //TODO: throw ApiException
                throw new HttpException(serverErrorResponse);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

