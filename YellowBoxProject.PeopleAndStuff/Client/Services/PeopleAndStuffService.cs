using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using YellowBoxProject.PeopleAndStuff.Models;

namespace YellowBoxProject.PeopleAndStuff.Services
{
    public class PeopleAndStuffService : ServiceBase, IPeopleAndStuffService, IService
    {
        public PeopleAndStuffService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("PeopleAndStuff");

        public async Task<List<Models.PeopleAndStuff>> GetPeopleAndStuffsAsync(int ModuleId)
        {
            List<Models.PeopleAndStuff> PeopleAndStuffs = await GetJsonAsync<List<Models.PeopleAndStuff>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return PeopleAndStuffs.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.PeopleAndStuff> GetPeopleAndStuffAsync(int PeopleAndStuffId, int ModuleId)
        {
            return await GetJsonAsync<Models.PeopleAndStuff>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PeopleAndStuffId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.PeopleAndStuff> AddPeopleAndStuffAsync(Models.PeopleAndStuff PeopleAndStuff)
        {
            return await PostJsonAsync<Models.PeopleAndStuff>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, PeopleAndStuff.ModuleId), PeopleAndStuff);
        }

        public async Task<Models.PeopleAndStuff> UpdatePeopleAndStuffAsync(Models.PeopleAndStuff PeopleAndStuff)
        {
            return await PutJsonAsync<Models.PeopleAndStuff>(CreateAuthorizationPolicyUrl($"{Apiurl}/{PeopleAndStuff.PeopleAndStuffId}", EntityNames.Module, PeopleAndStuff.ModuleId), PeopleAndStuff);
        }

        public async Task DeletePeopleAndStuffAsync(int PeopleAndStuffId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{PeopleAndStuffId}", EntityNames.Module, ModuleId));
        }
    }
}
