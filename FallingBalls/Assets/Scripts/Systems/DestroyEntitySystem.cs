using Components;
using Components.Events;
using Leopotam.Ecs;

namespace Systems
{
    internal class DestroyEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<EventDestroyEntity, DestroyComponent> _destroyFilter;

        public void Run()
        {
            foreach (var indexEntity in _destroyFilter)
            {
                ref var destroyComponent = ref _destroyFilter.Get2(indexEntity);
                
                ref var entity = ref _destroyFilter.GetEntity(indexEntity);

                destroyComponent.DeathEntity.Destroy(entity);
            }
        }
    }
}