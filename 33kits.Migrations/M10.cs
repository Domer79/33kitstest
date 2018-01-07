using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(10, "Add view MenuWithDish")]
    public class M10: Migration
    {
        public override void Up()
        {
            Sql(@"CREATE view [dbo].[MenuWithDish]
as
select 
	md.id idMenu, 
	md.description menuDescription, 
	md.date menuDate, 
	d.id idDish, 
	d.description dishDescription, 
	d.name,
	d.dishCount
from 
	MenuOnDay md inner join (select d.*, md.idMenu, md.dishCount from MenuDish md inner join Dish d on md.idDish = d.id) d 
on 
	md.id = d.idMenu");
        }

        public override void Down()
        {
            Sql("drop view [dbo].[MenuWithDish]");
        }
    }
}