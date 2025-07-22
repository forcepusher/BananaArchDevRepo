using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        public List<Transform> Waypoints;

        public PathProgress StartFollowing() => new(this);
    }
}
