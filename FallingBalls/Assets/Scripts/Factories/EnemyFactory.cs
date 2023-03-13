using Components;
using EnemyScripts;
using Helper;
using Interfaces;
using Leopotam.Ecs;
using Monobehavior;
using UnityEngine;

namespace Factories
{
    internal class EnemyFactory : IFactory
    {
        private const string EnemyResourcesPath = "EnemyPrefab/EnemyBall";

        private readonly Pool _poolEnemy;
        private readonly DamageableBehavior _damageableBehavior;
        private readonly Vector2 _spawnTopRightPosition;
        private readonly Vector2 _spawnTopLeftPosition;
        private readonly IDeathEntity _deathEntity;
        private readonly EnemyReset _resettable;

        public EnemyFactory(Pool poolEnemy, DamageableBehavior damageableBehavior, Vector2 spawnTopLeftPosition, Vector2 spawnTopRightPosition)
        {
            _poolEnemy = poolEnemy;
            _damageableBehavior = damageableBehavior;
            _spawnTopRightPosition = spawnTopRightPosition;
            _spawnTopLeftPosition = spawnTopLeftPosition;

            _deathEntity = new DestroyEnemy(Object.FindObjectOfType<PlayerView>().Entity);
            
            _resettable = new EnemyReset(_spawnTopRightPosition, _spawnTopLeftPosition);
        }

        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();

            var enemyGO = Object.Instantiate(Resources.Load(EnemyResourcesPath)) as GameObject;

            var startPosition = VectorsHelper.GetRandomVectorByX(_spawnTopLeftPosition.x,
                _spawnTopRightPosition.x, Constants.StartPositionY);
            
            enemyGO.transform.position = startPosition;

            GetComponentEntity(entity, enemyGO);

            enemyGO.SetActive(false);

            _poolEnemy.Add(enemyGO);
        }

        private void GetComponentEntity(EcsEntity entity, GameObject enemyGO)
        {
            entity.Get<EnemyTagComponent>();

            ref var modelComponent = ref entity.Get<ModelComponent>();

            ref var damageComponent = ref entity.Get<DamageComponent>();

            ref var damageableComponent = ref entity.Get<DamageableComponent>();

            ref var healthComponent = ref entity.Get<HealthComponent>();

            ref var destroyComponent = ref entity.Get<DestroyComponent>();

            ref var gravityComponent = ref entity.Get<GravityComponent>();

            ref var boundsComponent = ref entity.Get<BoundsComponent>();

            ref var targetDamageable = ref entity.Get<TargetDamageableComponent>();

            ref var colorComponent = ref entity.Get<ColorComponent>();

            ref var scoreComponent = ref entity.Get<ScoreComponent>();

            ref var resetComponent = ref entity.Get<ResetComponent>();

            var entityView = enemyGO.GetComponent<EntityView>();

            SetVariables(enemyGO, ref damageComponent, ref modelComponent, entityView, entity, ref damageableComponent,
                ref healthComponent, ref destroyComponent, ref gravityComponent, ref boundsComponent,
                ref targetDamageable, ref colorComponent, ref scoreComponent, ref resetComponent);
        }

        private void SetVariables(GameObject enemyGO, ref DamageComponent damageComponent,
            ref ModelComponent modelComponent, EntityView entityView, EcsEntity entity,
            ref DamageableComponent damageableComponent, ref HealthComponent healthComponent,
            ref DestroyComponent destroyComponent, ref GravityComponent gravityComponent,
            ref BoundsComponent boundsComponent, ref TargetDamageableComponent targetDamageableComponent,
            ref ColorComponent colorComponent, ref ScoreComponent scoreComponent, ref ResetComponent resetComponent)
        {
            damageComponent.Damage = Constants.EnemyDamage;

            modelComponent.Transform = enemyGO.transform;

            modelComponent.Rigidbody2D = enemyGO.GetComponent<Rigidbody2D>();

            entityView.Entity = entity;

            damageableComponent.Damageable = _damageableBehavior;

            healthComponent.HealthValueCurrent = Constants.MaxHealth;

            gravityComponent.GravityScale = Random.Range(Constants.MinGravity, Constants.MaxGravity);

            modelComponent.Rigidbody2D.gravityScale = gravityComponent.GravityScale;

            modelComponent.SpriteRenderer = enemyGO.GetComponentInChildren<SpriteRenderer>();

            colorComponent.Colors = Constants.Colors;

            modelComponent.SpriteRenderer.color =
                colorComponent.Colors[(int) HelpfulFunction.GetRandomNumber(0, colorComponent.Colors.Length)];

            scoreComponent.Score = (int) HelpfulFunction.GetRandomNumber(Constants.MinScore, Constants.MaxScore);

            boundsComponent.OutOfRange = new EnemyOutOfRange();

            targetDamageableComponent.Target = Object.FindObjectOfType<PlayerView>().Entity;

            destroyComponent.DeathEntity = _deathEntity;

            resetComponent.Resettable = _resettable;
        }
    }
}