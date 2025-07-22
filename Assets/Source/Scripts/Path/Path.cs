using System;
using System.Collections.Generic;
using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        public List<Transform> Waypoints;

        public PathProgress StartFollowing()
        {
            if (Waypoints.Count < 2)
                throw new InvalidOperationException($"Cannot {nameof(StartFollowing)}. {nameof(Path)} must have at least two {nameof(Waypoints)}.");

            return new PathProgress(this);
        } 
    }
}
