using RocketApi.Abstractions;

namespace RocketApi.Entities
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
