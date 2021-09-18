using Oqtane.Models;
using Oqtane.Modules;

namespace YellowBoxProject.PeopleAndStuff
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "PeopleAndStuff",
            Description = "PeopleAndStuff",
            Version = "1.0.0",
            ServerManagerType = "YellowBoxProject.PeopleAndStuff.Manager.PeopleAndStuffManager, YellowBoxProject.PeopleAndStuff.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "YellowBoxProject.PeopleAndStuff.Shared.Oqtane"
        };
    }
}
