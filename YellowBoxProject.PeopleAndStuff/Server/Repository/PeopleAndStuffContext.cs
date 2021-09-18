using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace YellowBoxProject.PeopleAndStuff.Repository
{
    public class PeopleAndStuffContext : DBContextBase, IService, IMultiDatabase
    {
        public virtual DbSet<Models.PeopleAndStuff> PeopleAndStuff { get; set; }

        public PeopleAndStuffContext(ITenantManager tenantManager, IHttpContextAccessor accessor) : base(tenantManager, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
