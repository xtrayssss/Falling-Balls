using Components;
using Leopotam.Ecs;
using Monobehavior;
using UnityEngine;

namespace Systems
{
    internal class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTagComponent, PlayerInputComponent> _playerInputFilter;

        private readonly PlayerInputHandler _playerInputHandler;

        public PlayerInputSystem(PlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;
        }

        public void Run()
        {
            foreach (var indexEntity in _playerInputFilter)
            {
                ref var playerInputComponent = ref _playerInputFilter.Get2(indexEntity);

                playerInputComponent.MouseInput = Input.mousePosition;

                playerInputComponent.IsClickMouseButton = _playerInputHandler.IsClick;
            }
        }
    }
}