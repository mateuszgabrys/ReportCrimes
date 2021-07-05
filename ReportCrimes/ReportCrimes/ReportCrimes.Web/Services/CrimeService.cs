using ReportCrimes.Web.Models;
using ReportCrimes.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services
{
    public class CrimeService : BaseService, ICrimeService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CrimeService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> Create<T>(CrimeEventDto crimeEventDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = crimeEventDto,
                Url = SD.CrimeAPIBase + "/api/Crime/"
            });
        }

        public async Task<T> Delete<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.CrimeAPIBase + "/api/Crime/" + id
            });
        }

        public async Task<T> GetAll<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CrimeAPIBase + "/api/Crime"
            });
        }

        public async Task<T> GetSingle<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CrimeAPIBase + "/api/Crime/" + id
            });
        }

        public async Task<T> Update<T>(CrimeEventDto crimeEventDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = crimeEventDto,
                Url = SD.CrimeAPIBase + "/api/Crime/"
            });
        }
    }
}
