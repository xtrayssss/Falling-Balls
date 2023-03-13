using Components;
using Components.Events;
using Leopotam.Ecs;

namespace Systems
{
    internal class HealthCheckerSystem : IEcsRunSystem
    {
        private const int LowHealthThreshold = 0;

        private readonly EcsFilter<EventChangeHealth, HealthComponent> _healthCheckFilter;

        public void Run()
        {
            foreach (var indexEntity in _healthCheckFilter)
            {
                ref var healthComponent = ref _healthCheckFilter.Get2(indexEntity);

                ref var entity = ref _healthCheckFilter.GetEntity(indexEntity);

                if (healthComponent.HealthValueCurrent <= LowHealthThreshold)
                {
                    entity.Get<EventDestroyEntity>();
                }
            }
        }
    }
}