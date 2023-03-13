using Components;
using Components.Events;
using Helper;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class SwitcherComplexityGameSystem : IEcsRunSystem
    {
        private const float DifferenceBetweenGravity = 0.4f;

        private readonly EcsFilter<EventChangeCounter, CounterComponent> _complexityFilter;

        private readonly EcsFilter<PoolComponent, TimerComponent> _poolFilter;

        public void Run()
        {
            foreach (var indexEntity in _complexityFilter)
            {
                ref var counterComponent = ref _complexityFilter.Get2(indexEntity);

                if (counterComponent.Count % counterComponent.ValueChange == 0)
                {
                    ChangeGravity();
                }

                if (counterComponent.Count % 20 == 0)
                {
                    foreach (var index in _poolFilter)
                    {
                        ref var timerComponent = ref _poolFilter.Get2(index);

                        timerComponent.TotalAmountSecondsTimer -= 0.1f;
                    }
                }
            }
        }

        private void ChangeGravity()
        {
            if (MinGravityLess())
            {
                Constants.ChangeGravity(Constants.MinGravity += 0.2f, Constants.MaxGravity);
            }
            else
            {
                Constants.ChangeGravity(Constants.MinGravity, Constants.MaxGravity += 0.5f);
            }
        }

        private bool MinGravityLess() =>
            Constants.MinGravity < Constants.MaxGravity - DifferenceBetweenGravity;
    }
}