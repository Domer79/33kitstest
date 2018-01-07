using System.Collections.Generic;
using CommonContracts;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Collections
{
    public class ProductCollectionInfo: IEntityCollectionInfo<Product>
    {
        public int PageCount { get; set; }
        public int Count { get; set; }
        public IEnumerable<Product> Entities { get; set; }
    }
}