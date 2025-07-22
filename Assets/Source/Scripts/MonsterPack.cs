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

        public IEnumerator SpawnCoroutineFixedTime(float tickInterval, Vector3 position)
        {
            int spawnDelayTicks = Mathf.RoundToInt(_spawnDelay / tickInterval);
            int spawnIntervalTicks = Mathf.RoundToInt(_spawnInterval / tickInterval);

            int ticksSinceStart = 0;
            while (ticksSinceStart < spawnDelayTicks)
            {
                yield return null;
                ticksSinceStart += 1;
            }

            for (int spawnIteration = 1; spawnIteration <= _spawnQuantity; spawnIteration += 1)
            {
                GameObject.Instantiate(_monsterPrefab, position, Quaternion.identity);

                int ticksSinceLastSpawn = 0;
                while (ticksSinceLastSpawn < spawnIntervalTicks)
                {
                    yield return null;
                    ticksSinceLastSpawn += 1;
                }
            }
        }
    }
}
