using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(11, "Add table ProductImages")]
    public class M11: Migration
    {
        public override void Up()
        {
            Sql(@"create table ProductImages
(
	idProduct uniqueidentifier not null,
	idImage uniqueidentifier not null,
	constraint PK_ProductImages primary key (idProduct, idImage),
	constraint FK_ProductImages_Products foreign key (idProduct) references Products(id) on delete cascade,
	constraint FK_ProductImages_FileSystem foreign key (idImage) references FileSystem(id) on delete cascade
)");
        }

        public override void Down()
        {
            Sql("drop table ProductImages");
        }
    }
}