using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwarmApiService;

namespace SwarmAthonApi.Modules.Models
{
    public class CasesResponse
    {
        public string Version;
        public List<Case> Cases;
    }
}