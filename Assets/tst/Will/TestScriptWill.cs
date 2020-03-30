using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class Test
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
			SceneManager.LoadScene("Testing Scene", LoadSceneMode.Additive);
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			//PlayerMovement movement=mainCharacter.GetComponent<PlayerMovement>;
			//movement.move(Vector3.zero,true,false);
			yield return new WaitForSeconds(5);
            yield return null;
        }
    }
}
