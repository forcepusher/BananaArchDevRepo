using UnityEngine;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class Monster : MonoBehaviour
    {
        private const int TicksToExecuteUpdate = 2;

        [SerializeField]
        private PathReference _roadPathReference;
        [SerializeField]
        private float _movementSpeed = 2f;

        private PathProgress _pathProgress;
        private int _ticksSinceLastUpdate = 0;

        private void Start()
        {
            _pathProgress = _roadPathReference.Value.StartFollowing();
        }

        private void FixedUpdate()
        {
            _ticksSinceLastUpdate += 1;
            if (_ticksSinceLastUpdate < TicksToExecuteUpdate)
                return;
            
            _ticksSinceLastUpdate = 0;

            _pathProgress.Advance(_movementSpeed * Time.fixedDeltaTime * TicksToExecuteUpdate);
            transform.position = _pathProgress.Position;
        }

        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}
