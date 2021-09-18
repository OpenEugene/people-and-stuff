using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using YellowBoxProject.PeopleAndStuff.Models;

namespace YellowBoxProject.PeopleAndStuff.Repository
{
    public class PeopleAndStuffRepository : IPeopleAndStuffRepository, IService
    {
        private readonly PeopleAndStuffContext _db;

        public PeopleAndStuffRepository(PeopleAndStuffContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.PeopleAndStuff> GetPeopleAndStuffs(int ModuleId)
        {
            return _db.PeopleAndStuff.Where(item => item.ModuleId == ModuleId);
        }

        public Models.PeopleAndStuff GetPeopleAndStuff(int PeopleAndStuffId)
        {
            return GetPeopleAndStuff(PeopleAndStuffId, true);
        }

        public Models.PeopleAndStuff GetPeopleAndStuff(int PeopleAndStuffId, bool tracking)
        {
            if (tracking)
            {
                return _db.PeopleAndStuff.Find(PeopleAndStuffId);
            }
            else
            {
                return _db.PeopleAndStuff.AsNoTracking().FirstOrDefault(item => item.PeopleAndStuffId == PeopleAndStuffId);
            }
        }

        public Models.PeopleAndStuff AddPeopleAndStuff(Models.PeopleAndStuff PeopleAndStuff)
        {
            _db.PeopleAndStuff.Add(PeopleAndStuff);
            _db.SaveChanges();
            return PeopleAndStuff;
        }

        public Models.PeopleAndStuff UpdatePeopleAndStuff(Models.PeopleAndStuff PeopleAndStuff)
        {
            _db.Entry(PeopleAndStuff).State = EntityState.Modified;
            _db.SaveChanges();
            return PeopleAndStuff;
        }

        public void DeletePeopleAndStuff(int PeopleAndStuffId)
        {
            Models.PeopleAndStuff PeopleAndStuff = _db.PeopleAndStuff.Find(PeopleAndStuffId);
            _db.PeopleAndStuff.Remove(PeopleAndStuff);
            _db.SaveChanges();
        }
    }
}
