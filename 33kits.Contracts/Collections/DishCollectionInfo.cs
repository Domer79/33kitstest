using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonContracts;
using _33kits.Contracts.Poco;

namespace _33kits.Contracts.Collections
{
    public class DishCollectionInfo: IEntityCollectionInfo<Dish>
    {
        public int PageCount { get; set; }
        public int Count { get; set; }
        public IEnumerable<Dish> Entities { get; set; }
    }
}
