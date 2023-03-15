using Factories;
using Helper;
using Interfaces;
using Leopotam.Ecs;

namespace Systems
{
    internal class PoolInitSystem : IEcsInitSystem
    {
        private IFactory _poolFactory;
        
        private readonly EcsWorld _world;
        private readonly Pool _enemyPool;

        public PoolInitSystem(Pool enemyPool) => 
            _enemyPool = enemyPool;

        public void Init()
        {
            CreatePool();
        }

        private void CreatePool()
        {
            _poolFactory = new PoolFactory(_enemyPool);

            _poolFactory.CreateEntity(_world);
        }
    }
}