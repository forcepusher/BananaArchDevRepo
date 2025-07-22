using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class ArcherTower : MonoBehaviour
    {
        [SerializeField]
        private MonsterReferenceList _monsterReferenceList;

        [SerializeField]
        private ArrowProjectile _arrowProjectile;

        private void FixedUpdate()
        {
            // TODO: wrong, it should lock on targets
            float nearestMonsterDistance = float.PositiveInfinity;
            Monster nearestMonster = null;
            foreach (Monster monster in _monsterReferenceList.Values)
            {
                float monsterDistance = Vector3.Distance(transform.position, monster.transform.position);
                if (monsterDistance < nearestMonsterDistance)
                {
                    nearestMonsterDistance = monsterDistance;
                    nearestMonster = monster;
                }
            }
        }
    }
}
