using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class ArcherTower : MonoBehaviour
    {
        [SerializeField]
        private MonsterReferenceList _monsterReferenceList;
        [SerializeField]
        private ArrowProjectile _arrowProjectile;
        [SerializeField]
        private float _range;

        private Monster _target;

        private void FixedUpdate()
        {
            if (_target != null && Vector3.Distance(transform.position, _target.transform.position) > _range)
                _target = null;

            if (_target == null)
                _target = FindNearestTarget();
        }

        private Monster FindNearestTarget()
        {
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

            return nearestMonster;
        }
    }
}
