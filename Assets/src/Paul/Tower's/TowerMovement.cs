using System.Collections;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
	[Header("Game Objects")]
	//Public
	[Tooltip("An array that contains the locations that you would like the enemy to fire from.")]
	public GameObject[] weapons;
	[Tooltip("The prefab that you would like it to shoot.")]
	public GameObject bullet;

	//Misc
	private Animator animatorWeapon;
	private new readonly string name = "Gun_End";

	//Shooting Animation Functions
	public void Fire()
	{
		foreach (GameObject weapon in weapons)
		{
			Transform spawn = weapon.transform.FindDeepChild(name);
			animatorWeapon = weapon.GetComponent<Animator>();
			animatorWeapon.SetBool("Fire", true);
			GameObject clone = Instantiate(bullet, spawn.position , transform.rotation);
			Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
			cloneRB.velocity = transform.forward * 10;
		}
	}
	public void StopFire()
	{
		foreach (GameObject weapon in weapons)
		{
			animatorWeapon = weapon.GetComponent<Animator>();
			animatorWeapon.SetBool("stopFire", true);
		}
	}
}