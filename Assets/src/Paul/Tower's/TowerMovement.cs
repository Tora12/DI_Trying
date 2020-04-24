using System.Collections;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
	[Header("Game Objects")]
	//Public
	public GameObject[] weapArray;
	public GameObject Bullet;

	//Misc
	private Animator animatorWeap;
	private new readonly string name = "Gun_End";

	public void Fire()
	{
		foreach (GameObject weap in weapArray)
		{
			Transform spawn = weap.transform.FindDeepChild(name);
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
			GameObject clone = Instantiate(Bullet, spawn.position , transform.rotation);
			Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
			cloneRB.velocity = transform.forward * 10;
		}
	}

	public void stopFire()
	{
		foreach (GameObject weap in weapArray)
		{
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("stopFire", true);
		}
	}
}