using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestRunner;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScriptHunter
    {
        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Level_00", LoadSceneMode.Single);
        }
        [TearDown]
        public void Teardown()
        {

        }
        [UnityTest]
        public IEnumerator EnemyDropSpawnBoundaryTest()
        {
            yield return null;
        }
        [UnityTest]
        public IEnumerator boundTwo()
        {
            yield return null;
        }
        [UnityTest]
        public IEnumerator EnemyDropSpawnStressTest()
        {
            GameObject[] enemyDrops = PrefabLoader.LoadAllPrefabsAt(@"Assets/Prefabs/Hunter/EnemyDrops").ToArray();

            if(enemyDrops != null)
            {
                if(enemyDrops.Length > 0)
                {
                    for(int i = 0; i < 500; i++)
                    {
                        foreach (GameObject enemyDrop in enemyDrops)
                            GameObject.Instantiate(enemyDrop, Vector3.zero, Quaternion.identity);
                    }

                    Debug.Log("Test passed.");
                    yield break;
                }
                else
                    Debug.Log("Couldn't find any enemy drop prefabs.");
            }
            else
                Debug.Log("Couldn't load enemy drop prefabs.");

            Debug.Log("Test failed.");
            Assert.Fail();
            yield return null;
        }
    }
}
