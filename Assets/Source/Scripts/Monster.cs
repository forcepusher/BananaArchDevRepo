using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class Monster : MonoBehaviour, IPathAgent
    {
        [SerializeField]
        private PathReference _roadPathReference;

        public int CurrentWaypointIndex { get; set; } = 0;

        // Using FixedUpdate to make sure simulation remains sorta consistent on any framerate
        // Besides, achieving the stylized movement effect
        private void FixedUpdate()
        {
            //Vector3.MoveTowards(transform.position,)
        }
    }
}
