using System;
using CommonContracts;
using _33kits.Contracts.Infrastructure;

namespace _33kits.Contracts.Poco
{
    public class ProductMovement: Entity
    {
        public Guid IdProduct { get; set; }
        public int Count { get; set; }
        public MoveType MoveType { get; set; }
        public DateTime DateStamp { get; set; }
    }
}