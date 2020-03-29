﻿using System.Collections;
using UnityEngine;

public class TowerMovement : MonoBehaviour
{
	public GameObject[] weapArray;
	public GameObject Bullet;
	private Animator animatorWeap;
	private string name = "Gun_End";

	public void Fire()
	{
		foreach (GameObject weap in weapArray)
		{
			Transform spawn = weap.transform.FindDeepChild(name);
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
			GameObject clone = Instantiate(Bullet, spawn.position , Quaternion.identity);
			Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
			cloneRB.velocity = Vector3.forward * 10;
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