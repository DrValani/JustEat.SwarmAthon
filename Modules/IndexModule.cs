using System.Collections.Generic;
using Nancy;
using SwarmApiService;
using SwarmAthonApi.Views.Models;

namespace SwarmAthonApi.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule(IndexService indexService)
        {
            Get["/"] = parameters => View["index", indexService.AccumulateResults()];
        }
    }

    public class IndexService : IIndexService
    {
        private ResultRepository _resultRepository;

        public IndexService()
        {
            _resultRepository = new ResultRepository();
        }
        public Overview AccumulateResults()
        {
            var resultCounter = new Dictionary<string, int>();
            var results =_resultRepository.FetchAll();
            foreach (var resultRequest in results)
            {
                foreach (var c in resultRequest.Cases)
                {
                    if (resultCounter.ContainsKey(c.Result))
                    {
                        resultCounter[c.Result] += 1;
                    }
                    else
                    {
                        resultCounter.Add(c.Result,1);
                    }
                }
                
            }
            return new Overview()
            {
                Countries = 5,
                ErrorCount = 1,
                ResultCounter = resultCounter
            };
        }
    }

    public interface IIndexService
    {
    }
}