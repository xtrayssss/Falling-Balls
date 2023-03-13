using Components;
using Components.Events;
using Interfaces;
using Leopotam.Ecs;

namespace EnemyScripts
{
    internal class EnemyOutOfRange : IOutOfRange
    {
        public void OutOfRange(ref EcsEntity entity)
        {
            ref var targetEntity = ref entity.Get<TargetDamageableComponent>().Target;
            
            if (!targetEntity.IsAlive()) return;
            
            targetEntity.Get<EventChangeHealth>();

            ref var damageComponent = ref entity.Get<DamageComponent>();

            targetEntity.Get<DamageableComponent>().Damageable.TakeDamage(targetEntity, damageComponent.Damage);

            entity.Get<ModelComponent>().Transform.gameObject.SetActive(false);
        }
    }
}