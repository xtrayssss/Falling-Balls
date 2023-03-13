using Leopotam.Ecs;

namespace Interfaces
{
    internal interface IFactory
    {
        public void CreateEntity(EcsWorld world);
    }
}