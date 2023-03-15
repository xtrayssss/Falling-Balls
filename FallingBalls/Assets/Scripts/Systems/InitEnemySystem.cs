using EnemyScripts;
using Factories;
using Helper;
using Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class InitEnemySystem : IEcsInitSystem
    {
        private IFactory _enemyFactory;

        private readonly Pool _enemyPool;
        private readonly EcsWorld _world;
        private readonly Vector2 _spawnTopLeftPosition;
        private readonly DamageableBehavior _damageableBehavior;
        private readonly Vector2 _spawnTopRightPosition;

        public InitEnemySystem(Pool enemyPool, DamageableBehavior damageableBehavior, Vector2 spawnTopLeftPosition,
            Vector2 spawnTopRightPosition)
        {
            _enemyPool = enemyPool;
            _damageableBehavior = damageableBehavior;
            _spawnTopLeftPosition = spawnTopLeftPosition;
            _spawnTopRightPosition = spawnTopRightPosition;
        }

        public void Init() => 
            CreateEnemy();

        private void CreateEnemy()
        {
            _enemyFactory = new EnemyFactory(_enemyPool, _damageableBehavior, _spawnTopLeftPosition,
                _spawnTopRightPosition);

            for (var i = 0; i < Constants.AmountEnemy; i++)
            {
                _enemyFactory.CreateEntity(_world);
            }
        }
    }
    
    
}