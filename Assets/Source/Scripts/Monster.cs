using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class Monster : MonoBehaviour
    {
        [SerializeField]
        private PathReference _roadPathReference;
        [SerializeField]
        private float _movementSpeed = 2f;

        private PathProgress _pathProgress;

        private void Start()
        {
            _pathProgress = _roadPathReference.Value.StartFollowing();
        }

        private void FixedUpdate()
        {
            _pathProgress.Advance(_movementSpeed * Time.fixedDeltaTime);
            transform.position = _pathProgress.Position;
        }
    }
}
