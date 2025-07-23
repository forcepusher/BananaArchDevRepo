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
        public IEnumerator ArcherTower_OnFirstMap_KillsTenMonsters()
        {
            SceneListAsset mapList = Resources.Load<SceneListAsset>("MapList");

            yield return SceneManager.LoadSceneAsync(mapList.SceneReferences[0].SceneName);

            SpawnSequence spawnSequence = Object.FindFirstObjectByType<SpawnSequence>();
            spawnSequence.OverrideMonsterPacks(new List<MonsterPack>
            {
                //new MonsterPack
                //{
                //    _monsterPrefab = Resources.Load<Monster>("Monsters/Skeleton"),
                //    _spawnQuantity = 10,
                //    _spawnDelay = 0f,
                //    _spawnInterval = 0.1f
                //}
            });

            yield return null;
        }
    }
}
