using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(3, "Add ProductMovement table")]
    public class M3: Migration
    {
        public override void Up()
        {
            Sql(@"create table ProductMovement
(
	description nvarchar(100),
	idProduct uniqueidentifier not null,
	count int not null constraint CHK_ProductMovement_Count_Check check(count > 0),
	moveType int not null,
	DateStamp datetime2 not null default getdate(),
	constraint FK_ProductMovement_Products foreign key (idProduct) references Products(id)
)
");
        }

        public override void Down()
        {
            Sql("drop table ProductMovement");
        }
    }
}