using System;
using UnityEngine;

namespace BananaParty.Arch.Samples
{
    [Serializable]
    public class MonsterPack
    {
        [SerializeField]
        private GameObject _monsterPrefab;
        [SerializeField]
        private int _spawnQuantity = 5;
        [SerializeField]
        private float _spawnDelay = 1f;
        [SerializeField]
        private float _spawnInterval = 0.2f;
    }
}
