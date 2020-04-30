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
			health.resetPlayer();
			yield return new WaitForSeconds(2);
            yield return null;
        }
		[UnityTest]
		public IEnumerator Dash()
        {
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			PlayerMovement movement=mainCharacter.GetComponent<PlayerMovement>();			
			yield return new WaitForSeconds(1);
			movement.UnlockMovementAbillity("Dash");
			Vector3 startPos=mainCharacter.GetComponent<Transform>().position;
			int i;
			for(i=1; i<10; i++){
				movement.dashSpeed=12*i;
				movement.Move(Vector3.zero,false,true);
				yield return new WaitForSeconds(2);
				if(mainCharacter.GetComponent<Transform>().position.z > startPos.z+3) break;
				mainCharacter.GetComponent<Transform>().position=startPos;
			}
			Assert.IsTrue(i>3);
        }
		[UnityTest]
		public IEnumerator WalkLeft()
        {
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			PlayerMovement movement=mainCharacter.GetComponent<PlayerMovement>();
			Vector3 startPos=mainCharacter.GetComponent<Transform>().position;
			while(mainCharacter.GetComponent<Transform>().position.z-startPos.z>-2){
				Vector3 currentPos=mainCharacter.GetComponent<Transform>().position;
				movement.Move(Vector3.back,false,false);
				yield return new WaitForSeconds(0);
	
			}
			yield return null;
		}
    }
}
