using Components;
using EventsBus;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems
{
    internal class HealthBarSystems : IEcsRunSystem
    {
        private readonly EcsFilter<HealthBarComponent, HealthComponent> _healthBarFilter;
        private float _velocity;

        public void Run()
        {
            foreach (var indexEntity in _healthBarFilter)
            {
                ref var healthBarComponent = ref _healthBarFilter.Get1(indexEntity);

                ref var healthComponent = ref _healthBarFilter.Get2(indexEntity);

                healthBarComponent.FillFrontImage.fillAmount =
                    healthComponent.HealthValueCurrent / healthComponent.MaxHealthValue;
                
                var smoothFillAmount = Mathf.Lerp(healthBarComponent.FillBackImage.fillAmount,
                    healthBarComponent.FillBackImage.fillAmount = healthComponent.HealthValueCurrent / healthComponent.MaxHealthValue, healthBarComponent.SmoothSpeed * Time.deltaTime);

                healthBarComponent.FillBackImage.fillAmount = smoothFillAmount;
                
            }
        }
    }
}