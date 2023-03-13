using Components;
using Components.Events;
using Helper;
using Interfaces;
using Leopotam.Ecs;

namespace Factories
{
    internal class PoolFactory : IFactory
    {
        private readonly Pool _poolEnemy;

        public PoolFactory(Pool poolEnemy)
        {
            _poolEnemy = poolEnemy;
        }

        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();

            entity.Get<EventSpawn>();

            ref var poolComponent = ref entity.Get<PoolComponent>();

            ref var timerComponent = ref entity.Get<TimerComponent>();

            timerComponent.TotalAmountSecondsTimer = 1.0f;

            poolComponent.Pool = _poolEnemy;
        }
    }
}