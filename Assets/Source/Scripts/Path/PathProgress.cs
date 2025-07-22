using UnityEngine;

namespace BananaParty.Arch.Samples
{
    public class PathProgress
    {
        private readonly Path _path;

        private int _previousWaypointIndex = 0;
        private float _progressToNextWaypoint = 0f;

        public Vector3 PreviousWaypointPosition => _path.Waypoints[_previousWaypointIndex].position;

        public Vector3 NextWaypointPosition => _path.Waypoints[_previousWaypointIndex + 1].position;

        public Vector3 Position => Vector3.Lerp(PreviousWaypointPosition, NextWaypointPosition, _progressToNextWaypoint);    

        public PathProgress(Path path)
        {
            _path = path;
        }

        public void Advance(float movementDelta)
        {
            float distanceBetweenWaypoints = Vector3.Distance(PreviousWaypointPosition, NextWaypointPosition);
            _progressToNextWaypoint += movementDelta / distanceBetweenWaypoints;

            while (_progressToNextWaypoint >= 1f)
            {
                if (_previousWaypointIndex + 1 >= _path.Waypoints.Count)
                {
                    _progressToNextWaypoint = 1f;
                    return;
                }

                _progressToNextWaypoint -= 1f;
                _previousWaypointIndex += 1;
            }
        }
    }
}
