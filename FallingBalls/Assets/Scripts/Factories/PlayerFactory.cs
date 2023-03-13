using Components;
using Interfaces;
using Leopotam.Ecs;
using Monobehavior;
using PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Factories
{
    internal class PlayerFactory : IFactory
    {
        private readonly Image _fillBackImage;
        private readonly Image _fillFrontImage;
        private readonly TMP_Text _scoreText;
        private readonly TMP_Text _recordText;
        private readonly TMP_Text _destroyedBalls;
        private readonly GameObject _gameOverMenuGO;

        private const string PlayerResourcesPath = "Player/Player";

        public PlayerFactory(Image fillBackImage, Image fillFrontImage, TMP_Text scoreText, TMP_Text recordText,
            TMP_Text destroyedBalls, GameObject gameOverMenuGO)
        {
            _fillBackImage = fillBackImage;
            _fillFrontImage = fillFrontImage;
            _scoreText = scoreText;
            _recordText = recordText;
            _destroyedBalls = destroyedBalls;
            _gameOverMenuGO = gameOverMenuGO;
        }

        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();

            var playerGO = Object.Instantiate(Resources.Load(PlayerResourcesPath)) as GameObject;

            EventsBus.EventBus.InvokePlayerCreated(playerGO);

            GetComponentEntity(entity, playerGO);
        }

        private void GetComponentEntity(EcsEntity entity, GameObject playerGO)
        {
            entity.Get<PlayerTagComponent>();

            entity.Get<PlayerInputComponent>();

            entity.Get<RaycastComponent>();

            ref var damageComponent = ref entity.Get<DamageComponent>();

            ref var healthComponent = ref entity.Get<HealthComponent>();

            ref var damageableComponent = ref entity.Get<DamageableComponent>();

            ref var destroyComponent = ref entity.Get<DestroyComponent>();

            ref var modelComponent = ref entity.Get<ModelComponent>();

            ref var healthBarComponent = ref entity.Get<HealthBarComponent>();

            ref var counterComponent = ref entity.Get<CounterComponent>();

            ref var textScoreComponent = ref entity.Get<UITextComponent>();

            SetVariablesComponent(entity, ref damageComponent, ref healthComponent, ref damageableComponent, playerGO,
                ref destroyComponent, ref modelComponent, ref healthBarComponent, ref counterComponent,
                ref textScoreComponent);
        }

        private void SetVariablesComponent(EcsEntity entity, ref DamageComponent damageComponent,
            ref HealthComponent healthComponent,
            ref DamageableComponent damageableComponent, GameObject playerGO, ref DestroyComponent destroyComponent,
            ref ModelComponent modelComponent, ref HealthBarComponent healthBarComponent,
            ref CounterComponent counterComponent, ref UITextComponent uiTextComponent)
        {
            damageComponent.Damage = 5;

            healthComponent.MaxHealthValue = 100.0f;

            healthComponent.HealthValueCurrent = healthComponent.MaxHealthValue;

            healthComponent.LastValueHealth = healthComponent.HealthValueCurrent;

            modelComponent.Transform = playerGO.transform;

            damageableComponent.Damageable = new PlayerDamageable();

            playerGO.GetComponent<PlayerView>().Entity = entity;

            destroyComponent.DeathEntity = new PlayerDeath(_gameOverMenuGO);

            healthBarComponent.FillBackImage = _fillBackImage;

            healthBarComponent.FillFrontImage = _fillFrontImage;

            healthBarComponent.SmoothSpeed = 1.5f;

            counterComponent.ValueChange = 3;

            uiTextComponent.FirstText = _scoreText;

            uiTextComponent.SecondText = _recordText;

            uiTextComponent.ThirdText = _destroyedBalls;
            
            uiTextComponent.UIText = new ScoreSetter();
        }
    }
}