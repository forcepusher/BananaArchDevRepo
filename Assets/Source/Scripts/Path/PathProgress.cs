using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class PathProgress
    {
        private readonly Path _path;

        private int _currentWaypointIndex = 0;
        private float _progressToNextWaypoint = 0f;

        public Vector3 PreviousWaypointPosition => _path.Waypoints[_currentWaypointIndex].position;

        public Vector3 NextWaypointPosition => _path.Waypoints[_currentWaypointIndex + 1].position;

        public Vector3 Position => Vector3.Lerp(PreviousWaypointPosition, NextWaypointPosition, _progressToNextWaypoint);    

        public PathProgress(Path path)
        {
            _path = path;
        }

        public void Advance(float movementDelta)
        {
            float distanceBetweenWaypoints = Vector3.Distance(PreviousWaypointPosition, NextWaypointPosition);

        }
    }
}
