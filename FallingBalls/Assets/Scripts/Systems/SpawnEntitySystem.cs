using System.Linq;
using Components;
using Components.Events;
using Leopotam.Ecs;
using TMPro.Examples;

namespace Systems
{
    internal class SpawnEntitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<PoolComponent, TimerComponent>.Exclude<BlockTimerSpawn> _poolFilter;

        private int _indexer;

        private int _amountDisableEntities;

        public void Run()
        {
            foreach (var indexEntity in _poolFilter)
            {
                ref var entity = ref _poolFilter.GetEntity(indexEntity);

                ref var poolComponent = ref _poolFilter.Get1(indexEntity);

                ref var timerComponent = ref _poolFilter.Get2(indexEntity);

                if (_indexer < poolComponent.Pool.GetLength())
                {
                    poolComponent.Pool.GetGameObject(_indexer)
                        .SetActive(true);

                    entity.Get<BlockTimerSpawn>();

                    timerComponent.Timer = timerComponent.TotalAmountSecondsTimer;

                    _indexer++;
                }

                if (_indexer >= poolComponent.Pool.GetLength())
                {
                    _amountDisableEntities = poolComponent.Pool.GetPool().Count(x => !x.activeSelf);
                }

                if (_amountDisableEntities == poolComponent.Pool.GetLength())
                {
                    _indexer = 0;
                    _amountDisableEntities = 0;

                    entity.Get<EventResetComponent>();
                }
            }
        }
    }

    internal class BossSpawnSystem : IEcsRunSystem
    {
        public void Run()
        {
        }
    }
}