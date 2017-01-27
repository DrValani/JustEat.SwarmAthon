using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;
using SwarmApiService;

namespace SwarmAthonApi.Modules
{
    public class ResultModule : NancyModule
    {
        private readonly IResultRepository _service;

        public ResultModule(IResultRepository service)
        {
            _service = service;
            Get["/result"] = parameters =>
            {
                var result = this.Bind<ResultRequest>();
                return Response.AsJson(result);
            };
            Post["/result"] = parameters =>
            {                
                var result = this.Bind<ResultRequest>();
                var validationResult = this.Validate(result);

                if (!validationResult.IsValid)
                {
                    return Negotiate.WithModel(validationResult).WithStatusCode(HttpStatusCode.BadRequest);
                }
                _service.Save(result);
                return HttpStatusCode.NoContent;
            };
        }
    }
 }
    