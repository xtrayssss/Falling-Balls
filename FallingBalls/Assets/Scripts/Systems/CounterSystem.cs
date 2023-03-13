using Components;
using Components.Events;
using Leopotam.Ecs;

namespace Systems
{
    internal class CounterSystem : IEcsRunSystem
    {
        private EcsFilter<EventChangeCounter, CounterComponent> _counterFilter;

        public void Run()
        {
            foreach (var indexEntity in _counterFilter)
            {
                ref var counterComponent = ref _counterFilter.Get2(indexEntity);

                counterComponent.Count++;
            }
        }
    }
}