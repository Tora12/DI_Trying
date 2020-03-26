using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//needed to load the scene
using UnityEngine.SceneManagement;

namespace Tests
{
    public class TemplateTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestWithEnumeratorPasses()
        {
			//load a scene
			SceneManager.LoadScene("Testing Scene", LoadSceneMode.Additive);
			//find an object in scene
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			//wait for a period of seconds
			yield return new WaitForSeconds(5);
			//return success
            yield return null;
        }
    }
}
