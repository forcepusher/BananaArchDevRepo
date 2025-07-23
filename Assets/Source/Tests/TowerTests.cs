using System.Collections;
using System.Collections.Generic;
using BananaParty.Arch.TestUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace BananaParty.Arch.TowerDefenseSample.Tests
{
    public class TowerTests
    {
        [UnityTest]
        public IEnumerator ArcherTower_OnFirstMap_KillsTenSkeletons()
        {
            SceneListAsset mapList = Resources.Load<SceneListAsset>("MapList");

            yield return SceneManager.LoadSceneAsync(mapList.SceneReferences[0].SceneName);

            SpawnPoint spawnPoint = Object.FindFirstObjectByType<SpawnPoint>();
            SpawnSequence tenSkeletonsSpawnSequence = Resources.Load<SpawnSequence>("TenSkeletonsSpawnSequence");
            spawnPoint.OverrideSpawnSequence(tenSkeletonsSpawnSequence);

            yield return new WaitUntil(() =>
            {
                if (spawnPoint.Finished)
                    return true;
                // Wait for the spawn sequence to finish
                return false;
            });
        }
    }
}
