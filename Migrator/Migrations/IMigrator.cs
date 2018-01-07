namespace Migrator.Migrations
{
    public interface IMigrator
    {
        void Up();
        void Down(string name);
    }
}