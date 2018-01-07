using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(14, "Add trigger for check duplicate menu date")]
    public class M14: Migration
    {
        public override void Up()
        {
            Sql(@"
CREATE TRIGGER [dbo].[CheckMenuDate] 
   ON  [dbo].[MenuOnDay]
   AFTER INSERT,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	if Exists(
		select 
			1
		from 
			(
				select
					md.Id,
					md.description,
					md.date
				from
					MenuOnDay md inner join inserted i
				on
					md.id <> i.id
			)s1
		where 
			DATEPART(YYYY, date) in (select DATEPART(YYYY, date) from inserted)
			and DATEPART(MM, date) in (select DATEPART(MM, date) from inserted)
			and DATEPART(DD, date) in (select DATEPART(DD, date) from inserted)
	)
	begin
		rollback
		raiserror(50001, -1, -1)
	end
END
");
        }

        public override void Down()
        {
            Sql("drop trigger CheckMenuDate");
        }
    }
}