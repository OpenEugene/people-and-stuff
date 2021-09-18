using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using YellowBoxProject.PeopleAndStuff.Repository;
using Oqtane.Controllers;
using System.Net;

namespace YellowBoxProject.PeopleAndStuff.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class PeopleAndStuffController : ModuleControllerBase
    {
        private readonly IPeopleAndStuffRepository _PeopleAndStuffRepository;

        public PeopleAndStuffController(IPeopleAndStuffRepository PeopleAndStuffRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _PeopleAndStuffRepository = PeopleAndStuffRepository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.PeopleAndStuff> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && ModuleId == AuthEntityId(EntityNames.Module))
            {
                return _PeopleAndStuffRepository.GetPeopleAndStuffs(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PeopleAndStuff Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.PeopleAndStuff Get(int id)
        {
            Models.PeopleAndStuff PeopleAndStuff = _PeopleAndStuffRepository.GetPeopleAndStuff(id);
            if (PeopleAndStuff != null && PeopleAndStuff.ModuleId == AuthEntityId(EntityNames.Module))
            {
                return PeopleAndStuff;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PeopleAndStuff Get Attempt {PeopleAndStuffId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PeopleAndStuff Post([FromBody] Models.PeopleAndStuff PeopleAndStuff)
        {
            if (ModelState.IsValid && PeopleAndStuff.ModuleId == AuthEntityId(EntityNames.Module))
            {
                PeopleAndStuff = _PeopleAndStuffRepository.AddPeopleAndStuff(PeopleAndStuff);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "PeopleAndStuff Added {PeopleAndStuff}", PeopleAndStuff);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PeopleAndStuff Post Attempt {PeopleAndStuff}", PeopleAndStuff);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                PeopleAndStuff = null;
            }
            return PeopleAndStuff;
        }

        // PUT api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.PeopleAndStuff Put(int id, [FromBody] Models.PeopleAndStuff PeopleAndStuff)
        {
            if (ModelState.IsValid && PeopleAndStuff.ModuleId == AuthEntityId(EntityNames.Module) && _PeopleAndStuffRepository.GetPeopleAndStuff(PeopleAndStuff.PeopleAndStuffId, false) != null)
            {
                PeopleAndStuff = _PeopleAndStuffRepository.UpdatePeopleAndStuff(PeopleAndStuff);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "PeopleAndStuff Updated {PeopleAndStuff}", PeopleAndStuff);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PeopleAndStuff Put Attempt {PeopleAndStuff}", PeopleAndStuff);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                PeopleAndStuff = null;
            }
            return PeopleAndStuff;
        }

        // DELETE api/<controller>/5
        [ValidateAntiForgeryToken]
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.PeopleAndStuff PeopleAndStuff = _PeopleAndStuffRepository.GetPeopleAndStuff(id);
            if (PeopleAndStuff != null && PeopleAndStuff.ModuleId == AuthEntityId(EntityNames.Module))
            {
                _PeopleAndStuffRepository.DeletePeopleAndStuff(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "PeopleAndStuff Deleted {PeopleAndStuffId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized PeopleAndStuff Delete Attempt {PeopleAndStuffId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
