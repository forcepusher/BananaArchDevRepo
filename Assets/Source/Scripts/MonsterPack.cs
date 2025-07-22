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

        public IEnumerator Spawn(Vector3 position)
        {
            yield return new WaitForSeconds(_spawnDelay);

            for (int spawnIteration = 1; spawnIteration <= _spawnQuantity; spawnIteration += 1)
            {
                GameObject.Instantiate(_monsterPrefab, position, Quaternion.identity);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }
    }
}
