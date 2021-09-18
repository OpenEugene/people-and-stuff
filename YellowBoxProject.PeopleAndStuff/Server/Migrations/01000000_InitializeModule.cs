using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using YellowBoxProject.PeopleAndStuff.Migrations.EntityBuilders;
using YellowBoxProject.PeopleAndStuff.Repository;

namespace YellowBoxProject.PeopleAndStuff.Migrations
{
    [DbContext(typeof(PeopleAndStuffContext))]
    [Migration("PeopleAndStuff.01.00.00.00")]
    public class InitializeModule : MultiDatabaseMigration
    {
        public InitializeModule(IDatabase database) : base(database)
        {
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new PeopleAndStuffEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Create();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var entityBuilder = new PeopleAndStuffEntityBuilder(migrationBuilder, ActiveDatabase);
            entityBuilder.Drop();
        }
    }
}
