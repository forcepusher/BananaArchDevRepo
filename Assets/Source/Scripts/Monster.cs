using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class Monster : MonoBehaviour
    {
        [SerializeField]
        private PathReference _roadPathReference;
        [SerializeField]
        private float _movementSpeed = 1f;

        private PathProgress _pathProgress;

        private void Start()
        {
            _pathProgress = _roadPathReference.Value.StartFollowing();
        }

        // Using FixedUpdate to make sure simulation remains sorta consistent on any framerate
        // Besides, achieving the stylized movement effect
        private void FixedUpdate()
        {
            _pathProgress.Advance(_movementSpeed * Time.fixedDeltaTime);
            transform.position = _pathProgress.Position;
        }
    }
}
