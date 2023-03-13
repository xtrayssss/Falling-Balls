using UnityEngine;

namespace PlayerScripts
{
    internal class RecordSaver
    {
        public void SaveRecord(int score, string namePlayerPrefs, int defaultValue)
        {
            if (IsRecord(score, namePlayerPrefs, defaultValue))
            {
                PlayerPrefs.SetInt(namePlayerPrefs, score);
            }
        }

        public int GetPlayerPrefs(string namePlayerPrefs, int defaultValue) =>
            PlayerPrefs.GetInt(namePlayerPrefs, defaultValue);

        private bool IsRecord(int score, string namePlayerPrefs, int defaultValue) =>
            score > PlayerPrefs.GetInt(namePlayerPrefs, defaultValue);
    }
}