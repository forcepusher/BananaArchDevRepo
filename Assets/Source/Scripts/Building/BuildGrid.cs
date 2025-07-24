using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

namespace BananaParty.Arch.TowerDefenseSample
{
    public class BuildGrid : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Grid _grid;

        [SerializeField]
        private Tilemap _groundTilemap;
        [SerializeField]
        private Tilemap _roadTilemap;
        [SerializeField]
        private Tilemap _noBuildZoneTilemap;

        [SerializeField]
        private ArcherTower _archerTowerPrefab;

        private readonly HashSet<Vector3Int> _busyTiles = new();

        public void OnPointerClick(PointerEventData pointerClickEventData)
        {
            RaycastResult clickRaycastResult = pointerClickEventData.pointerCurrentRaycast;
            if (!clickRaycastResult.gameObject.TryGetComponent(out Tilemap clickedTilemap))
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
                Vector3Int gridSpacePosition = _grid.WorldToCell(clickRaycastResult.worldPosition);

                if (_busyTiles.Contains(gridSpacePosition))
                {
                    Debug.Log("Can't build on top of other buildings.");
                    return;
                }

                GameObject.Instantiate(_archerTowerPrefab, _grid.GetCellCenterWorld(gridSpacePosition), Quaternion.identity);
                _busyTiles.Add(gridSpacePosition);
                Debug.Log(pointerClickEventData.position);
            }
            else
            {
                throw new Exception($"Received {nameof(OnPointerClick)} from an uknnown {nameof(Tilemap)} {clickedTilemap.name}");
            }
        }
    }
}
