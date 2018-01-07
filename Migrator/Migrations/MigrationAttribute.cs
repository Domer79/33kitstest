using System;

namespace Migrator.Migrations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MigrationAttribute: Attribute
    {
        public int Order { get; }
        public string Description { get; }

        public MigrationAttribute(int order, string description)
        {
            Order = order;
            Description = description;
        }
    }
}
