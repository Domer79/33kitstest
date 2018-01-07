using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(8, "Add view ProductsWithCount")]
    public class M8: Migration
    {
        public override void Up()
        {
            Sql(@"create view ProductsWithCount
as
select p.*, pm.productCount from Products p inner join (select idProduct, SUM(count) as productCount from ProductMovement group by idProduct) pm on p.id = pm.idProduct");
        }

        public override void Down()
        {
            Sql("drop view ProductsWithCount");
        }
    }
}