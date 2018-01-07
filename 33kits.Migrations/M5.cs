using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(5, "Add DishProducts table")]
    public class M5: Migration
    {
        public override void Up()
        {
            Sql(@"create table DishProducts
(
	idDish uniqueidentifier not null,
	idProduct uniqueidentifier not null,
    count int not null,
	constraint PK_DishProducts primary key (idDish, idProduct),
	constraint FK_DishProducts_Dish foreign key (idDish) references Dish(id) on delete cascade,
	constraint FK_DishProducts_Products foreign key (idProduct) references Products(id) on delete cascade
)
");
        }

        public override void Down()
        {
            Sql("drop table DishProducts");
        }
    }
}