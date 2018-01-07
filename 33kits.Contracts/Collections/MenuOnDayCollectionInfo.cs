using System.Collections.Generic;
using CommonContracts;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Collections
{
    public class MenuOnDayCollectionInfo: IEntityCollectionInfo<MenuOnDay>
    {
        public int PageCount { get; set; }
        public int Count { get; set; }
        public IEnumerable<MenuOnDay> Entities { get; set; }
    }
}