using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(4, "Add Dish table")]
    public class M4: Migration
    {
        public override void Up()
        {
            Sql(@"create table Dish
(
	id uniqueidentifier not null primary key,
	description nvarchar(max),
	name nvarchar(100) not null
)

create unique index UQ_Dish_Name on Dish(name asc)
");
        }

        public override void Down()
        {
            Sql("drop table Dish");
        }
    }
}