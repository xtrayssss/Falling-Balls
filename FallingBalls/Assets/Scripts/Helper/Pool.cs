using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    internal class Pool
    {
        private readonly List<GameObject> _poolList = new List<GameObject>(5);

        //public Dictionary<GameObject, GameObject> Dictionary = new Dictionary<GameObject, GameObject>();
        
        public int GetLength() =>
            _poolList.Count;

        public void Add(GameObject gameObject) => 
            _poolList.Add(gameObject);

        public GameObject GetGameObject(int index) =>
            _poolList[index];

        public List<GameObject> GetPool() => 
            _poolList;
    }
}