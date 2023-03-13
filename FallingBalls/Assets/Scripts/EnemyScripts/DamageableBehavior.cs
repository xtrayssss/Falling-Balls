using Components;
using Interfaces;
using Leopotam.Ecs;

namespace EnemyScripts
{
    internal class DamageableBehavior : IDamageable
    {
        public void TakeDamage(EcsEntity entity, int damage) => 
            entity.Get<HealthComponent>().HealthValueCurrent -= damage;
    }
}