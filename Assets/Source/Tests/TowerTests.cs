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
            SpawnSequence tenSkeletonsSpawnSequence = Resources.Load<SpawnSequence>("TenSkeletons");
            spawnPoint.OverrideSpawnSequence(tenSkeletonsSpawnSequence);

            // Timescale at 5 for demonstration purposes. Crank it all the way to 100 for production.
            Time.timeScale = 5f;

            yield return new TimedWaitUntil(() => spawnPoint.SpawnSequenceFinished,
            TimeSpan.FromSeconds(20),
            () => Assert.Fail($"{nameof(SpawnSequence)} did not finish spawning within timeout period."),
            TimeoutMode.InGameTime);

            yield return new TimedWaitUntil(() => GameObject.FindObjectsOfType<Monster>().Length == 0,
            TimeSpan.FromSeconds(20),
            () => Assert.Fail($"{nameof(ArcherTower)} did not kill all {nameof(Monster)}."),
            TimeoutMode.InGameTime);
        }
    }
}
