using Components;
using Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace PlayerScripts
{
    internal class PlayerDamageable : IDamageable
    {
        public void TakeDamage(EcsEntity entity, int damage)
        {
            ref var healthComponent = ref entity.Get<HealthComponent>();

            healthComponent.LastValueHealth = healthComponent.HealthValueCurrent;
            
            healthComponent.HealthValueCurrent -= damage;

            healthComponent.HealthValueCurrent =
                Mathf.Clamp(healthComponent.HealthValueCurrent, 0, healthComponent.MaxHealthValue);
        }
    }
}