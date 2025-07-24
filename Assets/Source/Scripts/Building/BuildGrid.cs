using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class BuildGrid : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Tilemap _groundTilemap;
        [SerializeField]
        private Tilemap _roadTilemap;
        [SerializeField]
        private Tilemap _noBuildZoneTilemap;

        public void OnPointerClick(PointerEventData pointerClickEventData)
        {
            if (!pointerClickEventData.pointerCurrentRaycast.gameObject.TryGetComponent(out Tilemap clickedTilemap))
                return;

            if (clickedTilemap == _roadTilemap)
            {
                Debug.Log("Can't build on roads.");
                return;
            }

            if (clickedTilemap == _noBuildZoneTilemap)
            {
                Debug.Log("Can't build on other objects.");
                return;
            }

            if (clickedTilemap == _groundTilemap)
            {
                Debug.Log(pointerClickEventData.position);
            }
            else
            {
                throw new Exception($"Received {nameof(OnPointerClick)} from an uknnown {nameof(Tilemap)} {clickedTilemap.name}");
            }
        }
    }
}
