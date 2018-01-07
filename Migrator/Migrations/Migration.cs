using System.Collections.Generic;

namespace Migrator.Migrations
{
    public abstract class Migration
    {
        public List<string> Queries = new List<string>();

        public void Sql(string query)
        {
            Queries.Add(query);
        }

        public abstract void Up();

        public abstract void Down();
    }
}
