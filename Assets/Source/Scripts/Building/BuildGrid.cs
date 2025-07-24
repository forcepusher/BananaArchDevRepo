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

        private void Start()
        {
            // Sometimes creating Reference and Source scripts is not worth it
            foreach (ArcherTower archerTower in FindObjectsOfType<ArcherTower>())
                RegisterBuilding(archerTower);
        }

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

                PlaceBuilding(gridSpacePosition);
            }
            else
            {
                throw new Exception($"Received {nameof(OnPointerClick)} from an uknnown {nameof(Tilemap)} {clickedTilemap.name}");
            }
        }

        public void PlaceBuilding(Vector3Int gridSpacePosition)
        {
            GameObject.Instantiate(_archerTowerPrefab, _grid.GetCellCenterWorld(gridSpacePosition), Quaternion.identity);
            if (!_busyTiles.Add(gridSpacePosition))
                throw new InvalidOperationException($"Tried to {nameof(PlaceBuilding)} on a tile that is already busy: {gridSpacePosition}");
        }

        public void RegisterBuilding(ArcherTower archerTower)
        {
            Vector3Int gridSpacePosition = _grid.WorldToCell(archerTower.transform.position);
            if (!_busyTiles.Add(gridSpacePosition))
                throw new InvalidOperationException($"Tried to {nameof(RegisterBuilding)} on a tile that is already busy: {gridSpacePosition}");
        }
    }
}
