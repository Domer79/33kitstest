using System.Collections.Generic;

namespace Migrator.Migrations
{
    public interface IMigrationCollection: IEnumerable<Migration>
    {
        
    }
}