using System;
using System.Reflection;
using Migrator.Migrations;

namespace Migrator
{
    internal class MigrationInfo
    {
        public MigrationInfo()
        {
        }

        public MigrationInfo(Migration migration)
        {
            Migration = migration;
            Attribute = migration.GetType().GetCustomAttribute<MigrationAttribute>();
            Name = migration.GetType().Name;
        }

        public string Name { get; set; }
        public MigrationAttribute Attribute { get; set; }
        public Migration Migration { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
