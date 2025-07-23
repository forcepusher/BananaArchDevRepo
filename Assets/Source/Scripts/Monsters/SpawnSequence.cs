using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class SpawnSequence : MonoBehaviour
    {
        [SerializeField]
        private List<MonsterPack> _monsterPacks;

        private IEnumerator _spawnPacksCoroutine;

        private void Start()
        {
            _spawnPacksCoroutine = SpawnPacks();
        }

        private void FixedUpdate()
        {
            if (!_spawnPacksCoroutine.MoveNext())
                enabled = false;
        }

        private IEnumerator SpawnPacks()
        {
            foreach (MonsterPack monsterPack in _monsterPacks)
            {
                IEnumerator spawnCoroutine = monsterPack.SpawnCoroutineFixedTime(Time.fixedDeltaTime, transform.position);
                while (spawnCoroutine.MoveNext())
                    yield return spawnCoroutine.Current;
            }
        }
    }
}
