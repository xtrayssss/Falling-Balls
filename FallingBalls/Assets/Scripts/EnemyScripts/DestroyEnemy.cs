using Components;
using Components.Events;
using Helper;
using Interfaces;
using Leopotam.Ecs;
using PlayerScripts;
using UnityEngine;

namespace EnemyScripts
{
    internal class DestroyEnemy : IDeathEntity
    {
        private readonly EcsEntity _playerEntity;
        
        private readonly ScoreTextUpdater _scoreTextUpdater;
        private readonly RecordSaver _recordSaver;
        private readonly AddingScore _addingScore;

        public DestroyEnemy(EcsEntity playerEntity)
        {
            _playerEntity = playerEntity;

            _recordSaver = new RecordSaver();

            _scoreTextUpdater = new ScoreTextUpdater(_recordSaver);

            _addingScore = new AddingScore();
        }

        public void Destroy(EcsEntity entity)
        {
            ref var modelComponent = ref entity.Get<ModelComponent>();

            ref var counterComponent = ref _playerEntity.Get<CounterComponent>();

            ref var scoreComponent = ref entity.Get<ScoreComponent>();

            _playerEntity.Get<EventChangeCounter>();

            _playerEntity.Get<EventChangeText>();

            var explosionEffect = LoadEffect();

            explosionEffect = Object.Instantiate(explosionEffect);

            explosionEffect.transform.position = modelComponent.Transform.position;

            UpdateTextUI(ref scoreComponent, ref counterComponent, 0);

            modelComponent.Transform.gameObject.SetActive(false);
        }

        private void UpdateTextUI(ref ScoreComponent scoreComponent, ref CounterComponent counterComponent,
            int defaultValue)
        {
            _addingScore.AddScore(ref scoreComponent);

            _recordSaver.SaveRecord(_addingScore.GetScore(), Constants.NamePlayerPrefs, defaultValue);

            _scoreTextUpdater.TextsUpdate(_playerEntity, _addingScore.GetScore(), ref counterComponent, Constants.NamePlayerPrefs,
                defaultValue);
        }

        private GameObject LoadEffect() =>
            (GameObject) Resources.Load(Constants.ExplosionBallsPath);
    }
}