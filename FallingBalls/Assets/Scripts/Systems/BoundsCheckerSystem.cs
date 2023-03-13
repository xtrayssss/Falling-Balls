using Components;
using Components.Events;
using Helper;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class BoundsCheckerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ModelComponent, BoundsComponent> _boundsChecker;

        private readonly EcsFilter<PlayerTagComponent> _playerFilter;

        private readonly CalculatorBoundsScreen _calculatorBoundsScreen;

        public void Run()
        {
            foreach (var indexEntity in _boundsChecker)
            {
                ref var modelComponent = ref _boundsChecker.Get1(indexEntity);

                ref var boundsComponent = ref _boundsChecker.Get2(indexEntity);

                if (modelComponent.Transform.position.y < _calculatorBoundsScreen.DownBoundsPosition.y &&
                    modelComponent.Transform.gameObject.activeSelf)
                {
                    ref var entity = ref _boundsChecker.GetEntity(indexEntity);

                    boundsComponent.OutOfRange.OutOfRange(ref entity);
                }
            }
        }
    }
}