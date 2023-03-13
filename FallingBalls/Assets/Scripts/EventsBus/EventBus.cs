using System;
using UnityEngine;

namespace EventsBus
{
    public static class EventBus
    {
        public static event Action<GameObject> PlayerCreated;

        public static event Action PlayerDestroyed; 

        public static void InvokePlayerCreated(GameObject player) =>
            PlayerCreated?.Invoke(player);

        public static void OnPlayerDestroyed() => 
            PlayerDestroyed?.Invoke();
    }
}