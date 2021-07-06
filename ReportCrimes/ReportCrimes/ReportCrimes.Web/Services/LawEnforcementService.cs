using ReportCrimes.Web.Models;
using ReportCrimes.Web.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReportCrimes.Web.Services
{
    public class LawEnforcementService : BaseService, ILawEnforcementService
    {
        private readonly IHttpClientFactory _clientFactory;
        public LawEnforcementService(IHttpClientFactory clientFactory) :base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> Create<T>(LawEnforcementDto lawEnforcementDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = lawEnforcementDto,
                Url = SD.LawEnforcementAPIBase + "/api/LawEnforcement/"
            });
        }

        public async Task<T> Delete<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = id,
                Url = SD.LawEnforcementAPIBase + "/api/LawEnforcement/" + id
            });
        }

        public async Task<T> GetAll<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LawEnforcementAPIBase + "/api/LawEnforcement"
            });
        }

        public async Task<T> GetSingle<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.LawEnforcementAPIBase + "/api/LawEnforcement/" + id
            });
        }

        public async Task<T> Update<T>(LawEnforcementDto lawEnforcementDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = lawEnforcementDto,
                Url = SD.LawEnforcementAPIBase + "/api/LawEnforcement/"
            });
        }
    }
}
