using System.Collections;
using BananaParty.Arch.TestUtilities;
using NUnit.Framework;
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

            //yield return new WaitUntil(() =>
            //{
            //    return spawnPoint.Started;
            //}, System.TimeSpan.FromSeconds(3), () => Assert.Fail($"{nameof(SpawnSequence)} did not start."));
        }
    }
}
