using LawEnforcementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LawEnforcementAPI.Services
{
    public class LawEnforcementService : BaseService, ILawEnforcementService
    {
        private readonly IHttpClientFactory _clientFactory;
        public LawEnforcementService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAll<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CrimeAPIBase + "/api/Crime"
            });
        }
    }
}
