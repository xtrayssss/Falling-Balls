using UnityEngine;

namespace Helper
{
    public static class HelpfulFunction
    {
        public static float GetRandomNumber(float minNumber, float maxNumber) => 
            Random.Range(minNumber, maxNumber);
    }
}