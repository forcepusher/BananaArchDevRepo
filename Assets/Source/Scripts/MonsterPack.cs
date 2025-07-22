using System;
using System.Collections;
using UnityEngine;

namespace BananaParty.Arch.Samples
{
    [Serializable]
    public class MonsterPack
    {
        [SerializeField]
        private Monster _monsterPrefab;
        [SerializeField]
        private int _spawnQuantity = 5;
        [SerializeField]
        private float _spawnDelay = 1f;
        [SerializeField]
        private float _spawnInterval = 0.2f;

        public IEnumerator SpawnCoroutineFixedTime(float deltaTime, Vector3 position)
        {
            float timeSinceStart = 0f;

            while (timeSinceStart < _spawnDelay)
            {
                timeSinceStart += deltaTime;
                yield return null;
            }

            for (int spawnIteration = 1; spawnIteration <= _spawnQuantity; spawnIteration += 1)
            {
                GameObject.Instantiate(_monsterPrefab, position, Quaternion.identity);

                float timeSinceSpawn = 0f;
                while (timeSinceSpawn < _spawnInterval)
                {
                    timeSinceSpawn += deltaTime;
                    yield return null;
                }
            }
        }
    }
}
