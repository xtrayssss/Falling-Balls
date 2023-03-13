using Components;
using Components.Events;
using Leopotam.Ecs;
using Monobehavior;

namespace Systems
{
    internal class ResetComponentSystem : IEcsRunSystem
    {
        private readonly EcsFilter<EventResetComponent, PoolComponent> _resetFilter;
        
        public void Run()
        {
            foreach (var indexEntity in _resetFilter)
            {
                ref var poolComponent = ref _resetFilter.Get2(indexEntity);

                for (var i = 0; i < poolComponent.Pool.GetLength(); i++)
                {
                    ref var entity = ref poolComponent.Pool.GetGameObject(i).GetComponent<EntityView>().Entity;

                    ref var resetComponent = ref entity.Get<ResetComponent>();

                    resetComponent.Resettable.ResetComponent(entity);
                }
            }
        }
    }
}