﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nutrition.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected T PerformOperationAndHandleExeptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }
    }
}
