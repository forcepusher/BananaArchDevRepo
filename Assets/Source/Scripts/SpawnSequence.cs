using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class SpawnSequence : MonoBehaviour
    {
        [SerializeField]
        private List<MonsterPack> _monsterPacks;

        public IEnumerator Start()
        {
            foreach (MonsterPack monsterPack in _monsterPacks)
                yield return monsterPack.Spawn(transform.position);
        }
    }
}
