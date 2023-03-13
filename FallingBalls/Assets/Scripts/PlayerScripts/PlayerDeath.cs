using Components;
using Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace PlayerScripts
{
    internal class PlayerDeath : IDeathEntity
    {
        private readonly GameObject _gameOverMenuGO;

        public PlayerDeath(GameObject gameOverMenuGO) =>
            _gameOverMenuGO = gameOverMenuGO;

        public void Destroy(EcsEntity entity)
        {
            entity.Get<ModelComponent>().Transform.gameObject.SetActive(false);

            _gameOverMenuGO.SetActive(true);
        }
    }
}