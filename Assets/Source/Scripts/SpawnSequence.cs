using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.Samples
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
            _spawnPacksCoroutine.MoveNext();
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
