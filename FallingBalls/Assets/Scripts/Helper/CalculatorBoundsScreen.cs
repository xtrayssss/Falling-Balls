using UnityEngine;

namespace Helper
{
    internal class CalculatorBoundsScreen
    {
        private Camera _camera;
        public Vector2 DownBoundsPosition { get; private set; }
        public Vector2 TopRightPosition { get; private set; }
        public Vector2 TopLeftPosition { get; private set; }

        public void CalculatedBounds()
        {
            _camera = Camera.main;

            DownBoundsPosition = _camera.ScreenToWorldPoint(Vector2.zero);

            TopRightPosition = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            TopLeftPosition = _camera.ScreenToWorldPoint(new Vector2(1, Screen.height));
        }
    }
}