using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwarmAthonApi.Views.Models
{
    public class Overview
    {
        public int ErrorCount;
        public int Countries;
        public Dictionary<string, int> ResultCounter;
        public int TotalScenarios => ScenariosPassed + ScenariosFailed;
        public int ScenariosFailed => ResultCounter["Failed"];

        public int ScenariosPassed => ResultCounter["Passed"];
    }
}