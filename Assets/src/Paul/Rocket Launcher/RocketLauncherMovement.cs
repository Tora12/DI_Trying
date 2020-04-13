using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherMovement : MonoBehaviour
{
	public GameObject[] weapArray;
	public GameObject Bullet;
	public float speed = 1.0f;
	public float rotationSpeed = 1.0f;
	public GameObject BulletSpawn;
	private const int forward = 1;
	private const int backward = 2;
	private const int left = 3;
	private const int right = 4;
	private Animator animator, animatorWeap;
	private Rigidbody rb;
	private int direction = 0;
	private int roat = 0;

	void Awake()
	{
		animator = GetComponentInChildren<Animator>();
		rb = GetComponentInChildren<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown("i"))
		{
			WalkForwad();
		}
		else if (Input.GetKeyDown("k"))
		{
			WalkBack();
		}
		else if (Input.GetKeyDown("u"))
		{
			TurnLeft();
		}
		else if (Input.GetKeyDown("o"))
		{
			TurnRight();
		}
		if (Input.GetKeyUp("i") || Input.GetKeyUp("k") || Input.GetKeyUp("j") || Input.GetKeyUp("l") || Input.GetKeyUp("u") || Input.GetKeyUp("o"))
		{
			Idle();
		}
	}

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

	public void Fire()
	{
		foreach (GameObject weap in weapArray)
		{
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
			GameObject clone = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity);
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

	public void Dead1()
	{
		animator.SetBool("Dead1", true);
	}
	public void Dead2()
	{
		animator.SetBool("Dead2", true);
	}
	public void Dead3()
	{
		animator.SetBool("Dead3", true);
	}
	public void Dead4()
	{
		animator.SetBool("Dead4", true);
	}
	public void Idle()
	{
		animator.SetBool("Idle", true);
		animator.speed = 1;
		direction = 0;
		roat = 0;
	}
	public void WalkForwad()
	{
		animator.SetBool("MoveForward", true);
		animator.speed = animator.speed * speed;
		direction = forward;
	}
	public void WalkBack()
	{
		animator.SetBool("MoveBack", true);
		animator.speed = animator.speed * speed;
		direction = backward;
	}
	public void TurnLeft()
    {
		animator.SetBool("MoveLeft", true);
		animator.speed = animator.speed * speed;
		roat = left;
	}
	public void TurnRight()
    {
		animator.SetBool("MoveRight", true);
		animator.speed = animator.speed * speed;
		roat = right;
	}
}
