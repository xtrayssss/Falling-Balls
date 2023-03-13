using UnityEngine;

namespace Helper
{
    public static class VectorsHelper
    {
        public static Vector3 GetRandomVectorByX(float minX, float maxX, float y) =>
            new Vector3(Random.Range(minX, maxX), y, 1);
    }
}