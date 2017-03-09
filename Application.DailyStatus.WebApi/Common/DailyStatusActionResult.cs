using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace Application.DailyStatus.WebApi.Common
{
    public class DailyStatusActionResult : IHttpActionResult
    {
        private Object data { get; set; }

        private ResponseStatus status { get; set; }

        private Dictionary<string, string> errorMessages { get; set; }

        public ApiResult Result { get; set; }

        public DailyStatusActionResult(Object resultData, ResponseStatus resultStatus)
        {
            this.data = resultData;
            this.status = resultStatus;
            this.Result = this.GetAPiResult();

        }

        public DailyStatusActionResult(Dictionary<string, string> errorMessages, ResponseStatus resultStatus = ResponseStatus.ValidationError)
        {
            this.status = resultStatus;
            this.errorMessages = errorMessages;
            this.Result = this.GetAPiResult();
        }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            //// Adding configuration to request, if we will not do it, it will throw exception.

            request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            HttpResponseMessage response = null;

            ApiResult resultData = this.GetAPiResult();
            if (this.status == ResponseStatus.Sucess)
            {
                response = request.CreateResponse(HttpStatusCode.OK, resultData);
            }
            else if (this.status == ResponseStatus.ValidationError)
            {
                response = request.CreateResponse(HttpStatusCode.BadRequest, resultData);
            }
            else if (this.status == ResponseStatus.NotFound)
            {
                response = request.CreateResponse(HttpStatusCode.NotFound, resultData);
            }
            else //ResponseStatus.Fail
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, resultData);
            }


            return Task.FromResult(response);
        }

        private ApiResult GetAPiResult()
        {
            ApiResult apiResult = new ApiResult();
            apiResult.ResponseData = this.data;
            apiResult.ResponseStatus = this.status;
            apiResult.ErrorMessages = this.errorMessages;
            return apiResult;
        }
    }
}