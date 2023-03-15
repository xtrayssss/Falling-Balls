using EnemyScripts;
using Factories;
using Interfaces;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    internal class PlayerInitSystem : IEcsInitSystem
    {
        private readonly Image _fillBackImage;
        private readonly Image _fillFrontImage;
        private readonly TMP_Text _scoreText;
        private readonly TMP_Text _recordText;
        private readonly TMP_Text _destroyedBallsText;
        private readonly GameObject _gameOverMenuGO;

        private IFactory _poolFactory;
        private IFactory _playerFactory;

        private readonly EcsWorld _world;

        public PlayerInitSystem(Image fillBackImage, Image fillFrontImage,
            TMP_Text scoreText, TMP_Text recordText, TMP_Text destroyedBallsText, GameObject gameOverMenuGO)
        {
            _fillBackImage = fillBackImage;
            _fillFrontImage = fillFrontImage;
            _scoreText = scoreText;
            _recordText = recordText;
            _destroyedBallsText = destroyedBallsText;
            _gameOverMenuGO = gameOverMenuGO;
        }

        public void Init() =>
            CreatePlayer();

        private void CreatePlayer()
        {
            _playerFactory = new PlayerFactory(_fillBackImage, _fillFrontImage, _scoreText, _recordText,
                _destroyedBallsText,
                _gameOverMenuGO);

            _playerFactory.CreateEntity(_world);
        }
    }
}