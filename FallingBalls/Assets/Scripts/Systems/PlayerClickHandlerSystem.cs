using Components;
using Components.Events;
using Leopotam.Ecs;
using Monobehavior;
using UnityEngine;

namespace Systems
{
    internal class PlayerClickHandlerSystem : IEcsRunSystem
    {
        private readonly PlayerInputHandler _playerInputHandler;
        
        private readonly EcsFilter<PlayerTagComponent, PlayerInputComponent, RaycastComponent> _playerFilter;

        private readonly Camera _camera = Camera.main;

        public PlayerClickHandlerSystem(PlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;
        }
        public void Run()
        {
            foreach (var indexEntity in _playerFilter)
            {
                ref var playerInputComponent = ref _playerFilter.Get2(indexEntity);

                ref var raycastComponent = ref _playerFilter.Get3(indexEntity);

                ref var playerEntity = ref _playerFilter.GetEntity(indexEntity);

                if (playerInputComponent.IsClickMouseButton)
                {
                    raycastComponent.RaycastHit2D = Physics2D.Raycast(
                        _camera.ScreenToWorldPoint(playerInputComponent.MouseInput),
                        Vector2.zero);

                    playerEntity.Get<EventHitEnemy>();
                    
                    _playerInputHandler.ResetClick();
                }
            }
        }
    }
}