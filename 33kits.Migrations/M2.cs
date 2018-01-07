using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(2, "Add Products table")]
    public class M2: Migration
    {
        public override void Up()
        {
            Sql(@"create table Products
(
	id uniqueidentifier not null primary key,
	description nvarchar(max),
	name nvarchar(100) not null,
	price money not null
)

create unique index UQ_products_name on Products(name asc)");
        }

        public override void Down()
        {
            Sql("drop table Products");
        }
    }
}