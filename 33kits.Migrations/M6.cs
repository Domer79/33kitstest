using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(6, "Add MenuOnDay table")]
    public class M6: Migration
    {
        public override void Up()
        {
            Sql(@"create table MenuOnDay
(
	id uniqueidentifier not null primary key,
	description nvarchar(max),
	date datetime2 not null default getdate()
)

create index IX_MenuOnDay_date_asc on MenuOnDay (date asc)
create index IX_MenuOnDay_date_desc on MenuOnDay (date desc)
");
        }

        public override void Down()
        {
            Sql(@"drop table MenuOnDay");
        }
    }
}