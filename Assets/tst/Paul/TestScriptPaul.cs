using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TestScriptPaul
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestScriptPaulSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestScriptPaulWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            //GameObject gameObject = Resources.Load<GameObject>("Prefabs/Enemies/Enemies/Tower_GaussGun.prefab");
           // yield return null;
            //load a scene
            SceneManager.LoadScene("Testing Scene", LoadSceneMode.Additive);
            //find an object in scene
            GameObject spawnEnemy = GameObject.Find("Canvas/Spawn Enemy");
            
            //spawnEnemy.EnemySpawn.Spawn();
            //wait for a period of seconds
            yield return new WaitForSeconds(5);
            //return success
            yield return null;
        }
    }
}
