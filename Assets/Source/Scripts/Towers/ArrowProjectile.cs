using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace BananaParty.Arch.Samples
{
    public class ArrowProjectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10f;

        private Monster _target;
        private Vector3 _lastKnownTargetPosition;
        private int _ticksToReachTarget;

        public void FlyAt(Monster target)
        {
            _target = target;
            _lastKnownTargetPosition = target.transform.position;

            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            float distancePerTick = _speed * Time.fixedDeltaTime;
            _ticksToReachTarget = 1 + Mathf.RoundToInt(distanceToTarget / distancePerTick);
        }

        private void FixedUpdate()
        {
            if (_target != null)
                _lastKnownTargetPosition = _target.transform.position;

            transform.position = Vector3.Lerp(transform.position, _lastKnownTargetPosition, 1f / _ticksToReachTarget);

            _ticksToReachTarget -= 1;

            if (_ticksToReachTarget <= 0)
            {
                if (_target != null)
                    _target.Kill();

                Destroy(gameObject);
            }
        }
    }
}
