using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyApp.URIHelper
{
    public static class RequestBuilder
    {
        public static GetURI BuildGetRequest(string baseUri)
        {
            return new GetURI(baseUri);
        }
    }
}
