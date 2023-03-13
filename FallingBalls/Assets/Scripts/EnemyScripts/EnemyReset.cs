using Components;
using Helper;
using Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace EnemyScripts
{
    internal class EnemyReset : IResettable
    {
        private readonly Vector2 _spawnTopRightPosition;
        private readonly Vector2 _spawnTopLeftPosition;

        public EnemyReset(Vector2 spawnTopLeftPosition, Vector2 spawnTopRightPosition)
        {
            _spawnTopRightPosition = spawnTopRightPosition;
            _spawnTopLeftPosition = spawnTopLeftPosition;
        }
        public void ResetComponent(EcsEntity entity)
        {
            ref var modelComponent = ref entity.Get<ModelComponent>();

            ref var healthComponent = ref entity.Get<HealthComponent>();

            ref var gravityComponent = ref entity.Get<GravityComponent>();

            ref var colorComponent = ref entity.Get<ColorComponent>();

            ref var scoreComponent = ref entity.Get<ScoreComponent>();

            ResetVariables(ref modelComponent, ref healthComponent, ref gravityComponent, ref colorComponent,
                ref scoreComponent);            
        }

        private void ResetVariables(ref ModelComponent modelComponent, ref HealthComponent healthComponent,
            ref GravityComponent gravityComponent, ref ColorComponent colorComponent, ref ScoreComponent scoreComponent)
        {
            modelComponent.Transform.position = VectorsHelper.GetRandomVectorByX(_spawnTopLeftPosition.x,
                _spawnTopRightPosition.x, Constants.StartPositionY);

            healthComponent.HealthValueCurrent = Constants.MaxHealth;

            gravityComponent.GravityScale =
                HelpfulFunction.GetRandomNumber(Constants.MinGravity, Constants.MaxGravity);

            modelComponent.Rigidbody2D.gravityScale = gravityComponent.GravityScale;

            modelComponent.SpriteRenderer.color =
                colorComponent.Colors[(int) HelpfulFunction.GetRandomNumber(0, colorComponent.Colors.Length)];

            scoreComponent.Score = (int) HelpfulFunction.GetRandomNumber(Constants.MinScore, Constants.MaxScore);
        }
    }
}