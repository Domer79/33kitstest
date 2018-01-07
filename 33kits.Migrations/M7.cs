using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(7, "Add MenuDish table")]
    public class M7: Migration
    {
        public override void Up()
        {
            Sql(@"create table MenuDish
(
	idMenu uniqueidentifier not null,
	idDish uniqueidentifier not null,
    dishCount int not null,
	constraint PK_DishMenu primary key (idMenu, idDish),
	constraint FK_MenuDish_MenuOnDay foreign key (idMenu) references MenuOnDay(id) on delete cascade,
	constraint FK_MenuDish_Dish foreign key (idDish) references Dish(id) on delete cascade
)
");
        }

        public override void Down()
        {
            Sql(@"drop table MenuDish");
        }
    }
}