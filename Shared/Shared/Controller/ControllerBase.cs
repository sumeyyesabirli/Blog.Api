using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Controller
{
    [Route("api/[controller]"), ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IClientFactory _clientFactory;
        IHttpContextAccessor _httpContextAccessor;

        public BaseController(IClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult CreateActionResultInstance<T>(ResponseItem<T> response)
        {
            if (response.Status == "OK")
            {
                var x = Ok(BaseResponseModel.Ok(response, HttpContext.TraceIdentifier));
                return x;
            }
            else
                return BadRequest(BaseResponseModel.BadRequest(ResponseMessageToString.ResponseMessageToStr(response.Messages), HttpContext.TraceIdentifier));
        }

        public async Task<Response<TResponse>> CustomRequestClient<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
            where TRequest : class
            where TResponse : class
        {
            var client = _clientFactory.CreateRequestClient<TRequest>().Create(request, cancellationToken, RequestTimeout.After(0, 0, 25));
            var res = await client.GetResponse<TResponse>();
            return res;
        }

    }
}
