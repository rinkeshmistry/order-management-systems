using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace OrderManagementApi.Common.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _requestDeletgate;
        private readonly IConfiguration _configuration;
        public AuthenticationMiddleware(RequestDelegate pNext, IConfiguration pConfiguration)
        {
            this._requestDeletgate = pNext;
            this._configuration = pConfiguration;
        }

        public async Task Invoke(HttpContext context)
        {
            StringValues reqHeaderKey = new StringValues();
            context.Request.Headers.TryGetValue("APIKey", out reqHeaderKey);
            var serverAPIKey = this._configuration.GetSection("ApiKey").Value;
            if (Utils.IsNullOrBlank(reqHeaderKey.ToString()) || serverAPIKey != reqHeaderKey.ToString())
            {
                throw new UnauthorizedAccessException();
            }
            await this._requestDeletgate(context);
        }
    }
}
