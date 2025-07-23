using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.TowerDefenseSample
{
    [CreateAssetMenu]
    public class SpawnSequence : ScriptableObject
    {
        [SerializeField]
        private List<MonsterPack> _monsterPacks;

        public IEnumerator SpawnPacksCoroutineFixedTime(float tickInterval, Vector3 position)
        {
            foreach (MonsterPack monsterPack in _monsterPacks)
            {
                IEnumerator spawnCoroutine = monsterPack.SpawnCoroutineFixedTime(tickInterval, position);
                while (spawnCoroutine.MoveNext())
                    yield return spawnCoroutine.Current;
            }
        }
    }
}
