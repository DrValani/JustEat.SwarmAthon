using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using SwarmApiService;
using SwarmAthonApi.Modules.Models;

namespace SwarmAthonApi.Modules
{
    public class CasesModule : NancyModule
    {
        public CasesModule()
        {
            Get["/cases"] = parameters =>
            {
                var cases = new CasesResponse()
                {
                    Version = "v00001",
                    Cases = GetCases()                    

                };
                return Response.AsJson(cases);
            };
        }

        private static List<Case> GetCases()
        {
            return new List<Case>()
            {
                new Case() { Id = "c00001",Result="Incomplete", Description = "Check sounds & alerts", Steps = new List<Case.Step>() {new Case.Step("Create new order", "Bhah"), new Case.Step("Alert should sound", "Bhah") } },
                new Case() { Id = "c00002",Result="Incomplete", Description = "Check receipt printing", Steps = new List<Case.Step>() { new Case.Step("Print an active order", "Bhah"), new Case.Step("Check menu items, address fields are displayed correctly", "Bhah")}},
                new Case() { Id = "c00003",Result="Incomplete", Description = "Check order summary printing ", Steps = new List<Case.Step>() { new Case.Step("Print an active order", "Bhah"), new Case.Step("Check its printed correctly", "Bhah")}},
            };
        }
    }
}