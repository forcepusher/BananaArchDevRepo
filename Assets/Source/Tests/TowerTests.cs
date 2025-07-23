using System.Collections;
using BananaParty.Arch.TestingUtility;
using UnityEngine;
using UnityEngine.TestTools;

namespace BananaParty.Arch.TowerDefenseSample.Tests
{
    public class TowerTests
    {
        [UnityTest]
        public IEnumerator ArcherTower_OnFirstMap_KillsTenMonsters()
        {
            SceneListAsset sceneAssetList = Resources.Load<SceneListAsset>("CatShouldReachCameraViewportTestSceneList");

            yield return null;
        }
    }
}
