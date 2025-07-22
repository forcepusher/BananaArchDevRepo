using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class PathProgress
    {
        private readonly Path _path;

        private int _currentWaypointIndex = 0;
        private float _progressToNextWaypoint = 0f;

        public Transform CurrentWaypoint => _path.Waypoints[_currentWaypointIndex];

        public Transform NextWaypoint => _path.Waypoints[_currentWaypointIndex + 1];

        public Vector3 Position => Vector3.Lerp(CurrentWaypoint.position, NextWaypoint.position, _progressToNextWaypoint);    

        public PathProgress(Path path)
        {
            _path = path;
        }

        public void Advance(float movementDelta)
        {

        }
    }
}
