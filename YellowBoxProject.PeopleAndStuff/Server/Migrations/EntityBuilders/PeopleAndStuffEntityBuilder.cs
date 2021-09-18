using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace YellowBoxProject.PeopleAndStuff.Migrations.EntityBuilders
{
    public class PeopleAndStuffEntityBuilder : AuditableBaseEntityBuilder<PeopleAndStuffEntityBuilder>
    {
        private const string _entityTableName = "YellowBoxProjectPeopleAndStuff";
        private readonly PrimaryKey<PeopleAndStuffEntityBuilder> _primaryKey = new("PK_YellowBoxProjectPeopleAndStuff", x => x.PeopleAndStuffId);
        private readonly ForeignKey<PeopleAndStuffEntityBuilder> _moduleForeignKey = new("FK_YellowBoxProjectPeopleAndStuff_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public PeopleAndStuffEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override PeopleAndStuffEntityBuilder BuildTable(ColumnsBuilder table)
        {
            PeopleAndStuffId = AddAutoIncrementColumn(table,"PeopleAndStuffId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> PeopleAndStuffId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
