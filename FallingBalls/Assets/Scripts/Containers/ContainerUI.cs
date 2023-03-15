using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Containers
{
    [Serializable]
    internal class ContainerUI
    {
        public Image fillBackImage;

        public Image fillFrontImage;

        public TMP_Text scoreText;

        public TMP_Text recordScoreText;

        public TMP_Text destroyedBallsText;
        
        public Texture2D cursorTexture;
        
        public GameObject gameOverMenuGO;
    }
}