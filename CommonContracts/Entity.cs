using System;

namespace CommonContracts
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{{ \"ProductUnit\": {{\"Code\" : \"{Id}\", \"Description\" : {Description}}} }}";
        }
    }
}