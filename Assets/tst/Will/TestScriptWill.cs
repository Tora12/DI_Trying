using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace Tests
{
    public class TestScriptWill
    {
		[SetUp]
		public void Setup()
		{
			SceneManager.LoadScene("Testing Scene 1", LoadSceneMode.Single);
		}
		[TearDown]
		public void Teardown()
		{
			
		}
        [UnityTest]
        public IEnumerator Jump()
        {
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			PlayerMovement movement=mainCharacter.GetComponent<PlayerMovement>();
			movement.Move(Vector3.zero,true,false);
			Assert.IsTrue(mainCharacter.GetComponent<Rigidbody>().velocity.y>9);
			yield return new WaitForSeconds(2);
            yield return null;
        }
		[UnityTest]
		public IEnumerator KillAndRespawn()
        {
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			PlayerHealthandDamage health=mainCharacter.GetComponent<PlayerHealthandDamage>();
			yield return new WaitForSeconds(2);
			health.killPlayer();
			yield return new WaitForSeconds(2);
			health.respawnPlayer();
			yield return new WaitForSeconds(2);
            yield return null;
        }
    }
}
