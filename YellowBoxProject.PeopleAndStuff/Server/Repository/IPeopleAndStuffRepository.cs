using System.Collections.Generic;
using YellowBoxProject.PeopleAndStuff.Models;

namespace YellowBoxProject.PeopleAndStuff.Repository
{
    public interface IPeopleAndStuffRepository
    {
        IEnumerable<Models.PeopleAndStuff> GetPeopleAndStuffs(int ModuleId);
        Models.PeopleAndStuff GetPeopleAndStuff(int PeopleAndStuffId);
        Models.PeopleAndStuff GetPeopleAndStuff(int PeopleAndStuffId, bool tracking);
        Models.PeopleAndStuff AddPeopleAndStuff(Models.PeopleAndStuff PeopleAndStuff);
        Models.PeopleAndStuff UpdatePeopleAndStuff(Models.PeopleAndStuff PeopleAndStuff);
        void DeletePeopleAndStuff(int PeopleAndStuffId);
    }
}
