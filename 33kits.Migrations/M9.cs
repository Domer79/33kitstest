using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(9, "Add view DishWithProducts")]
    public class M9 : Migration
    {
        public override void Up()
        {
            Sql(@"CREATE view [dbo].[DishWithProducts]
as
select  
	dp.idProduct,
	dp.idDish,
	dp.count productNeedCount,
	pwc.description productDescription,
	pwc.name productName,
	pwc.price,
	pwc.productCount allProductCount
from DishProducts dp left join ProductsWithCount pwc on dp.idProduct = pwc.id");
        }

        public override void Down()
        {
            Sql(@"drop view [dbo].[DishWithProducts]");
        }
    }
}