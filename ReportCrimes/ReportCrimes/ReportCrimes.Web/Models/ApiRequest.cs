using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ReportCrimes.Web.SD;

namespace ReportCrimes.Web.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccesToken { get; set; }
    }
}
