using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(13, "Add error message for duplicate date on menu")]
    public class M13: Migration
    {
        public override void Up()
        {
            Sql("sp_addmessage 50001, 16, 'This day the menu is already exist', @replace = 'replace'");
        }

        public override void Down()
        {
            
        }
    }
}