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
        private float _range = 10f;
        [SerializeField]
        private float _fireInterval = 1f;
        
        private Monster _target;
        private int _ticksSinceLastShot = 0;
        private int _fireIntervalTicks;

        private void Awake()
        {
            _fireIntervalTicks = Mathf.RoundToInt(_fireInterval / Time.fixedDeltaTime);
        }

        private void FixedUpdate()
        {
            if (_target != null && Vector3.Distance(transform.position, _target.transform.position) > _range)
                _target = null;

            if (_target == null)
                _target = FindNearestTarget();

            _ticksSinceLastShot += 1;
            if (_ticksSinceLastShot >= _fireIntervalTicks)
            {
                FireAt(_target);
                _ticksSinceLastShot = 0;
            }
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

        private void FireAt(Monster target)
        {
            GameObject.Instantiate(_arrowProjectile, transform.position, Quaternion.identity).FlyAt(target);
        }
    }
}
