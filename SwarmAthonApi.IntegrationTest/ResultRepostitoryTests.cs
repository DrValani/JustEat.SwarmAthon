using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using SwarmApiService;

namespace SwarmAthonApi.IntegrationTest
{
    public class ResultRepostitoryTests
    {
        private ResultRepository _resultRepository;

        [SetUp]
        public void SetUp()
        {
            _resultRepository = new ResultRepository();
        }

        [Test]
        public void SavesResultsToDynamo()
        {
            var resultRequest = new ResultRequest()
            {
              User  = new User() { Id = "user1", Name = "Yogi"},
              Cases = new List<Case>()
              {
                  new Case() {Result = "Passed"},
                  new Case() {Result = "Passed"},
                  new Case() {Result = "Failed"},
              },
              Country = "UK"
            };
            _resultRepository.Save(resultRequest);
        }

        [Test]
        public void FetchAllResultsFromDynamo()
        {
            var results = _resultRepository.FetchAll();
            Assert.That(results.Count(), Is.GreaterThan(0));
        }
    }
}
