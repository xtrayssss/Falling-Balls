using UnityEngine;
using UnityEngine.InputSystem;

namespace Monobehavior
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public bool IsClick { get; private set; }

        public void OnClick(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.started)
            {
                IsClick = true;
            }
        }

        public void ResetClick() => 
            IsClick =false;
    }
}