using System.Collections.Generic;
using System.Threading.Tasks;
using YellowBoxProject.PeopleAndStuff.Models;

namespace YellowBoxProject.PeopleAndStuff.Services
{
    public interface IPeopleAndStuffService 
    {
        Task<List<Models.PeopleAndStuff>> GetPeopleAndStuffsAsync(int ModuleId);

        Task<Models.PeopleAndStuff> GetPeopleAndStuffAsync(int PeopleAndStuffId, int ModuleId);

        Task<Models.PeopleAndStuff> AddPeopleAndStuffAsync(Models.PeopleAndStuff PeopleAndStuff);

        Task<Models.PeopleAndStuff> UpdatePeopleAndStuffAsync(Models.PeopleAndStuff PeopleAndStuff);

        Task DeletePeopleAndStuffAsync(int PeopleAndStuffId, int ModuleId);
    }
}
