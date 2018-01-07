using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Migrator.Migrations;

namespace _33kits.Migrations
{
    [Migration(1, "Add FileSystem table")]
    public class M1: Migration
    {
        public override void Up()
        {
            Sql(@"create table FileSystem
(
	id uniqueidentifier not null primary key,
	fileName nvarchar(100) not null,
	hash nvarchar(100) not null,
	data varbinary(max) not null
)

create index IX_FileSystem on FileSystem(fileName asc, hash)
create unique index UQ_FileSystem_Hash on FileSystem (hash)");
        }

        public override void Down()
        {
            Sql("drop table FileSystem");
        }
    }
}