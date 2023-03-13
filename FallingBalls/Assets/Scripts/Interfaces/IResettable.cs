using Leopotam.Ecs;

namespace Interfaces
{
    internal interface IResettable
    {
        public void ResetComponent(EcsEntity entity);
    }
}