using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using YellowBoxProject.PeopleAndStuff.Repository;

namespace YellowBoxProject.PeopleAndStuff.Manager
{
    public class PeopleAndStuffManager : MigratableModuleBase, IInstallable, IPortable
    {
        private IPeopleAndStuffRepository _PeopleAndStuffRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public PeopleAndStuffManager(IPeopleAndStuffRepository PeopleAndStuffRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _PeopleAndStuffRepository = PeopleAndStuffRepository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new PeopleAndStuffContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new PeopleAndStuffContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Models.PeopleAndStuff> PeopleAndStuffs = _PeopleAndStuffRepository.GetPeopleAndStuffs(module.ModuleId).ToList();
            if (PeopleAndStuffs != null)
            {
                content = JsonSerializer.Serialize(PeopleAndStuffs);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.PeopleAndStuff> PeopleAndStuffs = null;
            if (!string.IsNullOrEmpty(content))
            {
                PeopleAndStuffs = JsonSerializer.Deserialize<List<Models.PeopleAndStuff>>(content);
            }
            if (PeopleAndStuffs != null)
            {
                foreach(var PeopleAndStuff in PeopleAndStuffs)
                {
                    _PeopleAndStuffRepository.AddPeopleAndStuff(new Models.PeopleAndStuff { ModuleId = module.ModuleId, Name = PeopleAndStuff.Name });
                }
            }
        }
    }
}