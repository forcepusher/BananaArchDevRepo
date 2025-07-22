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

        // TODO: Relying on update and waitforseconds is incorrect.
        // Need to rely on FixedUpdate, manually calling
        public IEnumerator Spawn(Vector3 position)
        {
            float timeSinceStart = 0f;

            while (timeSinceStart < _spawnDelay)
            {
                timeSinceStart += Time.fixedDeltaTime;
                yield return null;
            }

            for (int spawnIteration = 1; spawnIteration <= _spawnQuantity; spawnIteration += 1)
            {
                GameObject.Instantiate(_monsterPrefab, position, Quaternion.identity);

                float timeSinceSpawn = 0f;
                while (timeSinceSpawn < _spawnInterval)
                {
                    timeSinceSpawn += Time.fixedDeltaTime;
                    yield return null;
                }
            }
        }
    }
}
