using System.Collections;
using BananaParty.Arch.TestUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace BananaParty.Arch.TowerDefenseSample.Tests
{
    public class TowerTests
    {
        [UnityTest]
        public IEnumerator ArcherTower_OnFirstMap_KillsTenMonsters()
        {
            SceneListAsset mapList = Resources.Load<SceneListAsset>("MapList");

            yield return SceneManager.LoadSceneAsync(mapList.SceneReferences[0].SceneName);

            SpawnSequence spawnSequence = Object.FindFirstObjectByType<SpawnSequence>();

            yield return null;
        }
    }
}
