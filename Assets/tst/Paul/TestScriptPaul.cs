using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
//needed to load the scene
using UnityEngine.SceneManagement;
//needed to load prefabs
using UnityEditor;

namespace Tests
{
	public class TestScriptPaul
	{
		//put scene set up common to all tests here
		[SetUp]
		public void Setup()
		{
			//load a scene
			SceneManager.LoadScene("Testing Scene 1", LoadSceneMode.Single);
		}
		//same for tear down
		[TearDown]
		public void Teardown()
		{

		}

		[UnityTest]
		public IEnumerator EnemyFire()
		{
			//find an object in scene
			GameObject enemy = GameObject.Find("Tower_RocketLauncher");
			//get a component of a certain class from an object
			TowerMovement movement = enemy.GetComponent<TowerMovement>();
			//call a function from the class
			movement.Fire();
			//assert the truth of somthing (test fails if not true)
			Assert.IsTrue(GameObject.FindGameObjectWithTag("EnemyBullet"));
			//wait for a period of seconds
			yield return new WaitForSeconds(5);
			//return success
			yield return null;
		}

		[UnityTest]
		public IEnumerator EnemyMovement()
		{
			GameObject enemy = GameObject.Find("LaserGun");
			AutoCannonMovement movement = enemy.GetComponent<AutoCannonMovement>();
			movement.StrafeLeft();
			Assert.IsTrue(enemy.GetComponent<Rigidbody>().velocity.x != 0);
			//wait for a period of seconds
			yield return new WaitForSeconds(2);
			movement.Idle();
			movement.StrafeRight();
			Assert.IsTrue(enemy.GetComponent<Rigidbody>().velocity.x != 0);
			//wait for a period of seconds
			yield return new WaitForSeconds(2);
			movement.Idle();
			movement.WalkForwad();
			Assert.IsTrue(enemy.GetComponent<Rigidbody>().velocity.z != 0);
			//wait for a period of seconds
			yield return new WaitForSeconds(2);
			movement.Idle();
			movement.WalkBack();
			Assert.IsTrue(enemy.GetComponent<Rigidbody>().velocity.z != 0);
			//wait for a period of seconds
			yield return new WaitForSeconds(2);
			movement.Idle();
			yield return null;
		}

		[UnityTest]
		public IEnumerator EnemyStressTest()
		{
			GameObject enemy = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Paul/Enemies/AutoCannon.prefab");
			//there is no error message if the path is wrong so check that the call worked
			if (enemy != null)
			{
				GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
				for (int i = 0; i < 100; i++)
				{
					GameObject.Instantiate(enemy);
					yield return new WaitForSeconds(1);
				}
				
			}
			else Debug.Log("Bullet Not Loaded\n");

			yield return null;
		}
	}
}
