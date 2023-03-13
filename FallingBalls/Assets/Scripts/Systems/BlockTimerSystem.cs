using Components;
using Leopotam.Ecs;

namespace Systems
{
    internal class BlockTimerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockTimerSpawn, TimerComponent> _blockTimerFilter;

        public void Run()
        {
            foreach (var indexEntity in _blockTimerFilter)
            {
                ref var timerComponent = ref _blockTimerFilter.Get2(indexEntity);

                ref var entity = ref _blockTimerFilter.GetEntity(indexEntity);

                if (timerComponent.Timer <= 0)
                {
                    entity.Del<BlockTimerSpawn>();
                }
            }
        }
    }
}