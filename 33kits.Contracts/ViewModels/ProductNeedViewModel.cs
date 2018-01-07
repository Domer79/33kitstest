using System;

namespace _33kits.Contracts.ViewModels
{
    public class ProductNeedViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NeedCount { get; set; }
        public string NeedSum { get; set; }
        public Guid? IdImage { get; set; }
    }
}