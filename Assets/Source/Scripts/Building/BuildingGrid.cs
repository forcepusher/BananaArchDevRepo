using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class BuildingGrid : MonoBehaviour
    {
        [SerializeField]
        private Tilemap _groundTilemap;
        [SerializeField]
        private Tilemap _roadTilemap;
        [SerializeField]
        private Tilemap _noBuildZoneTilemap;

        public void OnGroundClickOrTap(BaseEventData eventData)
        {
            PointerEventData pointerEventData = eventData as PointerEventData;
            Debug.Log(pointerEventData.position);
            //Debug.Log("Click");
        }
    }
}
