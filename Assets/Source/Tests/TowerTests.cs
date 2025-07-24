using System;
using System.Collections;
using BananaParty.Arch.TestUtilities;
using BananaParty.Arch.TestUtilities.Polyfills;
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

            SpawnPoint spawnPoint = GameObject.FindFirstObjectByType<SpawnPoint>();
            SpawnSequence tenSkeletonsSpawnSequence = Resources.Load<SpawnSequence>("TenSkeletonsSpawnSequence");
            spawnPoint.OverrideSpawnSequence(tenSkeletonsSpawnSequence);

            yield return new TimedWaitUntil(() => spawnPoint.SpawnSequenceFinished,
            TimeSpan.FromSeconds(20),
            () => Assert.Fail($"{nameof(SpawnSequence)} did not finish spawning within timeout period."),
            TimeoutMode.InGameTime);
        }
    }
}
