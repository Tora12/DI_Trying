using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
using UnityEngine.SceneManagement;
using UnityEditor;

namespace Tests {

  public class TestScriptJenner {

    [SetUp]
		public void Init() {
			// Loads "Testing Scene 1" as the scene used for all the following tests
			SceneManager.LoadScene("Testing Scene 1", LoadSceneMode.Single);
		}

    // EditMode Test?
    [Test]
    public void PrefabTagTest() {

      // Finds and stores Bullet.prefab asset into GameObject variable called bulletPrefab
      GameObject bulletPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Jenner/Bullet.prefab");

      if(bulletPrefab != null) {
        // Compares the expected "Bullet" tag to the actual Bullet.prefab tag
        Assert.AreEqual("Bullet", bulletPrefab.tag, "Comparing bulletPrefab.tag to the tag 'Bullet'");
      } else {
        Debug.Log("Unable to load Bullet.prefab");
        Assert.Fail();
      }
      /*************************************************************************
      if("Bullet" == bulletPrefab.tag) {
        Debug.Log("bulletPrefab has the tag of Bullet");
      } else {
        Debug.Log("bulletPrefab does not have the tag of Bullet");
        Assert.Fail();
      }
      *************************************************************************/
    }

    [UnityTest]
    public IEnumerator BulletShootRightTest() {

      // Finds and stores Bullet.prefab asset into GameObject variable called bullet
      GameObject bullet = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Jenner/Bullet.prefab");

      if(bullet != null) {
        yield return new WaitForSeconds(3); // Use if you need some time to find coordinates (0, 0, 0) in "Testing Scene 1"

        // Instantiate a Bullet.prefab GameObject at coordinates (0, 0, 0) moving
        // to the right (positve z-axis direction) and assign to GameObject variable called bulletClone
        GameObject bulletClone = GameObject.Instantiate(bullet, Vector3.forward, Quaternion.identity);

        yield return new WaitForSeconds(1.1f); // Gives .1f seconds margin of error

        // First condition handles when bulletClone returns a "normal" null reference
        // second condition handles when bulletClone returns a "fake" null reference
        if(bulletClone == null || bulletClone.Equals(null)) {
          Debug.Log("bulletClone successfully despawned");
          yield break; // returns success
        } else {
          Debug.Log("bulletClone failed to despawn");
          Assert.Fail();
        }
        /***********************************************************************
        // Almost always fails because we expect null but bulletClone returns <null>
        Assert.IsNull(bulletClone, "test if bulletClone despawned");
        ***********************************************************************/
      } else {
        Debug.Log("Unable to load Bullet.prefab");
        Assert.Fail();
      }
    }

    [UnityTest]
    public IEnumerator BulletShootLeftTest() {

      // Finds and stores Bullet.prefab asset into GameObject variable called bullet
      GameObject bullet = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Jenner/Bullet.prefab");

      if(bullet != null) {
        yield return new WaitForSeconds(3); // Use if you need some time to find coordinates (0, 0, 0) in "Testing Scene 1"

        // Instantiate a Bullet.prefab GameObject at coordinates (0, 0, 0) moving
        // to the left (negative z-axis direction) and assign to GameObject variable called bulletClone
        GameObject bulletClone = GameObject.Instantiate(bullet, Vector3.forward, Quaternion.FromToRotation(Vector3.forward, Vector3.back));

        yield return new WaitForSeconds(1.1f); // Gives .1f seconds margin of error

        // First condition handles when bulletClone returns a "normal" null reference
        // second condition handles when bulletClone returns a "fake" null reference
        if(bulletClone == null || bulletClone.Equals(null)) {
          Debug.Log("bulletClone successfully despawned");
          yield break; // returns success
        } else {
          Debug.Log("bulletClone failed to despawn");
          Assert.Fail();
        }
        /***********************************************************************
        // Almost always fails because we expect null but bulletClone returns <null>
        Assert.IsNull(bulletClone, "test if bulletClone despawned");
        ***********************************************************************/
      } else {
        Debug.Log("Unable to load Bullet.prefab");
        Assert.Fail();
      }
    }

    [UnityTest]
    public IEnumerator BulletShootStressTest() {

      float spawnTime = 0.3f;

      // Finds and stores Bullet.prefab asset into GameObject variable called bullet
      GameObject bullet = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Jenner/Bullet.prefab");

      if(bullet != null) {
        yield return new WaitForSeconds(3); // Use if you need some time to find coordinates (0, 0, 0) in "Testing Scene 1"

        // Continuously instantiate Bullet.prefab GameObjects at coordinates (0, 0, 0) moving
        // down (negative y-axis direction) and decrease spawnTime after 3 spawned Bullet.prefabs
        for (int i = 0; i < 1000; i++)
				{
          if((i % 3) == 0) {
            spawnTime -= 0.01f;

            // Checks if Bullet.prefab GameObjects can handle a spawning rate faster than human reaction speed
            if(spawnTime <= 0.06f) {
              Debug.Log(spawnTime);
              //Assert.AreApproximatelyEqual(0.06f, spawnTime);
              yield break; // returns success
            }
          }
          GameObject.Instantiate(bullet, Vector3.forward, Quaternion.FromToRotation(Vector3.forward, Vector3.back));
          yield return new WaitForSeconds(spawnTime);
				}

      } else {
        Debug.Log("Unable to load Bullet.prefab");
        Assert.Fail();
      }

      Debug.Log(spawnTime);
      yield return 1;
    }
  }
}
