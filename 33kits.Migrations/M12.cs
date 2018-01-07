using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(12, "Add table DishImages")]
    public class M12: Migration
    {
        public override void Up()
        {
            Sql(@"create table DishImages
(
	idDish uniqueidentifier not null,
	idImage uniqueidentifier not null,
	constraint PK_DishImages primary key (idDish, idImage),
	constraint FK_DishImages_Dish foreign key (idDish) references Dish(id) on delete cascade,
	constraint FK_DishImages_FileSystem foreign key (idImage) references FileSystem(id) on delete cascade
)
");
        }

        public override void Down()
        {
            Sql("create table DishImages");
        }
    }
}