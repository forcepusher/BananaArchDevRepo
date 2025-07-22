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

        public void FlyAt(Monster target)
        {
            _target = target;
            _lastKnownTargetPosition = target.transform.position;
        }

        private void FixedUpdate()
        {
            if (_target != null)
                _lastKnownTargetPosition = _target.transform.position;

            float distancePerTick = _speed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _lastKnownTargetPosition, distancePerTick);
            
            if (Vector3.Distance(transform.position, _lastKnownTargetPosition) <= distancePerTick * 0.25f)
            {
                if (_target != null)
                    _target.Kill();

                Destroy(gameObject);
            }
        }
    }
}
