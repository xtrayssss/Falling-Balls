using Components;
using Components.Events;
using Leopotam.Ecs;
using Monobehavior;
using UnityEngine;

namespace Systems
{
    internal class HittingEnemySystem : IEcsRunSystem
    {
        private EcsFilter<PlayerTagComponent, RaycastComponent, EventHitEnemy> _hitEnemyFilter;

        private EntityView _entityView;

        public void Run()
        {
            foreach (var indexEntity in _hitEnemyFilter)
            {
                ref var raycastComponent = ref _hitEnemyFilter.Get2(indexEntity);

                ref var raycastHit = ref raycastComponent.RaycastHit2D;

                if (CanHit(raycastHit, ref _entityView))
                {
                    ref var playerEntity = ref _hitEnemyFilter.GetEntity(indexEntity);

                    ref var hitEntity = ref _entityView.Entity;

                    hitEntity.Get<DamageableComponent>().Damageable
                        .TakeDamage(hitEntity, playerEntity.Get<DamageComponent>().Damage);

                    hitEntity.Get<EventChangeHealth>();
                }
            }
        }

        private bool CanHit(RaycastHit2D raycastHit, ref EntityView entityView) =>
            raycastHit.collider != null && raycastHit.collider.TryGetComponent(out entityView) &&
            entityView.Entity.Has<EnemyTagComponent>();
    }
}