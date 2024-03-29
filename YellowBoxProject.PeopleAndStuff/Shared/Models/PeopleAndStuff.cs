using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace YellowBoxProject.PeopleAndStuff.Models
{
    [Table("YellowBoxProjectPeopleAndStuff")]
    public class PeopleAndStuff : IAuditable
    {
        [Key]
        public int PeopleAndStuffId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
       // public PeopleOrStuff PeopleOrStuff { get; set; } = PeopleOrStuff.Stuff;

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }

    public enum PeopleOrStuff
    {
        People, Stuff
    }
}
