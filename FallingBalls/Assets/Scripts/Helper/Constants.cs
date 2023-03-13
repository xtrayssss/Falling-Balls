using UnityEngine;

namespace Helper
{
    internal static class Constants
    {
        public const float MinXStartPosition = -7.1f;

        public const float MaxXStartPosition = 9.1f;

        public const float StartPositionY = 5.0f;

        public const int EnemyDamage = 10;

        public static float MinGravity = 0.5f;

        public static float MaxGravity = 1.5f;

        public const int MaxHealth = 5;

        public const int MinScore = 10;

        public const int MaxScore = 31;

        public static readonly Color[] Colors =
        {
            new Color(0.96f, g: 0.67f, b: 0.71f),
            new Color(0f, g: 0.36f, b: 0.59f),
            new Color(0.4f, g: 0.12f, b: 0.24f),
            new Color(0.79f, g: 0.59f, 0.54f),
            new Color(0.44f, g: 0.5f, 0.56f),
            Color.white,
            Color.black,
            Color.yellow,
            Color.cyan,
            Color.red,
        };

        public const string ExplosionBallsPath = "Effects/ExplosionBalls";
        public const string NamePlayerPrefs = "RecordScore";

        public static readonly Vector2 LeftOffsetSpawn = new Vector2(1.88f, 0.0f);

        public static readonly Vector2 RightOffsetSpawn = new Vector2(-1.88f, 0.0f);

        public const int AmountEnemy = 3;

        public static void ChangeGravity(float minGravity, float maxGravity)
        {
            MinGravity = minGravity;
            MaxGravity = maxGravity;
        }

        public static void ResetStaticVariables()
        {
            MinGravity = 0.5f;
            MaxGravity = 1.5f;
        }
    }
}