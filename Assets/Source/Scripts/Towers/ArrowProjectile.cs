using UnityEngine;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class ArrowProjectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10f;

        private Monster _target;
        private Vector3 _lastKnownTargetPosition;

        public void FlyAt(Monster target)
        {
            _target = target;
            _lastKnownTargetPosition = target.transform.position;

            RotateTo(_lastKnownTargetPosition);
        }

        private void FixedUpdate()
        {
            if (_target != null)
                _lastKnownTargetPosition = _target.transform.position;

            RotateTo(_lastKnownTargetPosition);

            float distancePerTick = _speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _lastKnownTargetPosition, distancePerTick);
            
            if (Vector3.Distance(transform.position, _lastKnownTargetPosition) <= distancePerTick * 0.25f)
            {
                if (_target != null)
                    _target.Kill();

                Destroy(gameObject);
            }
        }

        private void RotateTo(Vector3 targetPosition)
        {
            Vector3 targetDirection = targetPosition - transform.position;
            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg);
        }
    }
}
