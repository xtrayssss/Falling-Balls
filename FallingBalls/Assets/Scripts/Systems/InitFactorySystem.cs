using EnemyScripts;
using Factories;
using Helper;
using Interfaces;
using Leopotam.Ecs;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    internal class InitFactorySystem : IEcsInitSystem
    {
        private readonly Pool _enemyPool;
        private readonly DamageableBehavior _damageableBehavior;
        private readonly Image _fillBackImage;
        private readonly Image _fillFrontImage;
        private readonly TMP_Text _scoreText;
        private readonly TMP_Text _recordText;
        private readonly TMP_Text _destroyedBallsText;
        private readonly GameObject _gameOverMenuGO;
        private readonly Vector2 _spawnTopRightPosition;
        private readonly Vector2 _spawnTopLeftPosition;

        private IFactory _poolFactory;
        private IFactory _enemyFactory;
        private IFactory _playerFactory;

        private EcsWorld _world;

        public InitFactorySystem(Pool enemyPool, DamageableBehavior damageableBehavior, Image fillBackImage, Image fillFrontImage,
            TMP_Text scoreText, TMP_Text recordText, TMP_Text destroyedBallsText, GameObject gameOverMenuGO,
            Vector2 spawnTopLeftPosition, Vector2 spawnTopRightPosition)
        {
            _enemyPool = enemyPool;
            _damageableBehavior = damageableBehavior;
            _fillBackImage = fillBackImage;
            _fillFrontImage = fillFrontImage;
            _scoreText = scoreText;
            _recordText = recordText;
            _destroyedBallsText = destroyedBallsText;
            _gameOverMenuGO = gameOverMenuGO;
            _spawnTopRightPosition = spawnTopRightPosition;
            _spawnTopLeftPosition = spawnTopLeftPosition;
        }

        public void Init()
        {
            CreatePlayer();

            CreateEnemy();

            CreatePool();
        }

        private void CreatePool()
        {
            _poolFactory = new PoolFactory(_enemyPool);

            _poolFactory.CreateEntity(_world);
        }

        private void CreatePlayer()
        {
            _playerFactory = new PlayerFactory(_fillBackImage, _fillFrontImage, _scoreText, _recordText, _destroyedBallsText,
                _gameOverMenuGO);

            _playerFactory.CreateEntity(_world);
        }

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