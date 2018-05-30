using System;
using System.Collections.Generic;
using System.Text;

namespace SunnyApp.ApiRequestHelper.Exceptions
{
    class HttpException : System.Exception
    {
        public HttpException(ServerErrorResponseModel serverErrorResponse)
            : base($"{serverErrorResponse.Message} {serverErrorResponse.Code}")
        {

        }
    }
}
