using Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class TimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TimerComponent> _timerTickFilter;
        public void Run()
        {
            foreach (var indexEntity in _timerTickFilter)
            {
                ref var timerComponent = ref _timerTickFilter.Get1(indexEntity);

                timerComponent.Timer -= Time.deltaTime;
            }
        }
    }
}