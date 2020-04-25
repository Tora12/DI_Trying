using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class TankMovement : MonoBehaviour
{
	[Header("Game Objects")]
	//Public
	[Tooltip("An array that contains the locations that you would like the enemy to fire from.")]
	public GameObject[] weapArray;
	[Tooltip("The prefab that you would like it to shoot.")]
	public GameObject Bullet;

	[Header("Speed Values")]
	//Public
	[Tooltip("The scale of the speed that you would like the enemy to move at.")]
	public float speed = 1.0f;
	[Tooltip("The scale of the speed that you would like the enemy to rotate at.")]
	public float rotationSpeed = 1.0f;

	//Direction Codes
	private const int forward = 1;
	private const int backward = 2;
	private const int left = 3;
	private const int right = 4;

	//Direction Indicators
	private int direction = 0;
	private int roat = 0;

	//Misc
	private Animator animator, animatorWeap;
	private Rigidbody rb;
	private new readonly string name = "Gun_End";

	void Awake()
    {
        animator = GetComponentInChildren<Animator>();
		rb = GetComponentInChildren<Rigidbody>();
    }

	//Handles Applying movement to the enemy.
	void OnAnimatorMove()
	{
		if (direction == forward)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		}
		else if (direction == backward)
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime, Space.Self);
		}
		else if (roat == left)
		{
			transform.Rotate(0.0f, -rotationSpeed, 0.0f, Space.Self);
		}
		else if (roat == right)
		{
			transform.Rotate(0.0f, rotationSpeed, 0.0f, Space.Self);
		}
	}

	public void Idle()
	{
		animator.SetBool("ACS_Idle", true);
		animator.speed = 1;
		direction = 0;
		roat = 0;
	}

	//Shooting Animation Functions
	public void Fire()
	{
		foreach (GameObject weap in weapArray)
		{
			Transform spawn = weap.transform.FindDeepChild(name);
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
			GameObject clone = Instantiate(Bullet, spawn.position, transform.rotation);
			Rigidbody cloneRB = clone.GetComponent<Rigidbody>();
			cloneRB.velocity = transform.forward * 10;
		}
	}
	public void StopFire()
	{
		foreach (GameObject weap in weapArray)
		{
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("stopFire", true);
		}
	}

	//Death Animation State Functions
	public void Dead1()
	{
		animator.SetBool("ACS_Dead1", true);
	}
	public void Dead2()
	{
		animator.SetBool("ACS_Dead2", true);
	}

	//Movement Animation Functions
	public void WalkForwad()
	{
		animator.SetBool("ACS_WalkForwad", true);
		animator.speed = animator.speed * speed;
		direction = forward;
	}
	public void WalkBack()
	{
		animator.SetBool("ACS_WalkBack", true);
		animator.speed = animator.speed * speed;
		direction = backward;
	}

	//Rotation Animation Functions
	public void TurnLeft()
	{
		animator.SetBool("ACS_TurnLeft", true);
		animator.speed = animator.speed * rotationSpeed;
		roat = left;
	}
	public void TurnRight()
	{
		animator.SetBool("ACS_TurnRight", true);
		animator.speed = animator.speed * rotationSpeed;
		roat = right;
	}
}
