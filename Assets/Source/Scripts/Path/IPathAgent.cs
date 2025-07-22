using System.Numerics;

namespace BananaParty.Arch.Samples
{
    public interface IPathAgent
    {
        int CurrentWaypointIndex { get; set; }

        public void Move(Vector3 position);
    }
}
