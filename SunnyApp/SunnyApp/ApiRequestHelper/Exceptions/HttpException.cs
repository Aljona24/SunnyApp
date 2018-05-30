using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyApp.ApiRequestHelper.Exceptions
{
    class HttpException : System.Exception
    {
        public HttpException()
        {
            ServerErrorResponse = null;
        }

        public HttpException(ServerErrorResponseModel serverErrorResponse)
        {
            ServerErrorResponse = serverErrorResponse;
        }

        public ServerErrorResponseModel ServerErrorResponse { get; }
    }
}
