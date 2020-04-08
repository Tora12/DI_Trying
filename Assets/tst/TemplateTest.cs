using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
//needed to load the scene
using UnityEngine.SceneManagement;
//needed to load prefabs
using UnityEditor;

namespace Tests
{
    public class TemplateTest
    {
		//put scene set up common to all tests here
        [SetUp]
		public void Setup()
		{
			//load a scene
			SceneManager.LoadScene("Testing Scene", LoadSceneMode.Single);
		}
		//same for tear down
		[TearDown]
		public void Teardown()
		{
			
		}
		
        [UnityTest]
        public IEnumerator Templatetest1()
        {
			//find an object in scene
            GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
			//get a component of a certain class from an object
			PlayerMovement movement=mainCharacter.GetComponent<PlayerMovement>();
			//call a function from the class
			movement.Move(Vector3.zero,true,false);
			//assert the truth of somthing (test fails if not true)
			Assert.IsTrue(mainCharacter.GetComponent<Rigidbody>().velocity.y>9);
			//wait for a period of seconds
			yield return new WaitForSeconds(5);
			//return success
            yield return null;
        }
		//you can have more than one test in the script file
		[UnityTest]
        public IEnumerator TemplateTest2()
        {
			//get a prefab
			GameObject Bullet = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Paul/Enemies Projectlies/AutoCannon Bullet.prefab");
			//there is no error message if the path is wrong so check that the call worked
			if(Bullet!=null){
				GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
				//create a new object
				GameObject bullet = GameObject.Instantiate(Bullet,mainCharacter.GetComponent<Transform>().position + Vector3.back*3,Quaternion.identity);
				//edit the object
				bullet.GetComponent<Rigidbody>().velocity=Vector3.forward*10;
			}else Debug.Log("Bullet Not Loaded\n");
			yield return new WaitForSeconds(5);
            yield return null;
        }
    }
}
