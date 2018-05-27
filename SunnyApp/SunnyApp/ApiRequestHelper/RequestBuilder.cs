using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyApp.ApiRequestHelper
{
    public static class RequestBuilder
    {
        public static GetRequest BuildGetRequest(string baseUri)
        {
            return new GetRequest(baseUri);
        }
    }
}
