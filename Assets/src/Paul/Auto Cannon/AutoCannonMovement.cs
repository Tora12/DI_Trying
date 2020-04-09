using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class AutoCannonMovement : MonoBehaviour
{
	public GameObject[] weapArray;
	public GameObject Bullet;
	public float speed = 1.0f;
	public float rotationSpeed = 1.0f;
	private const int forward = 1;
	private const int backward = 2;
	private const int left = 3;
	private const int right = 4;
    private Animator animator, animatorWeap;
	private Rigidbody rb;
	private int direction = 0;
	private int roat = 0;
	private string name = "Gun_End";

	void Awake()
    {
        animator = GetComponentInChildren<Animator>();
		rb = GetComponentInChildren<Rigidbody>();
    }

	/*
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
		else if (Input.GetKeyDown("j"))
        {
			StrafeLeft();
        }
		else if (Input.GetKeyDown("l"))
		{
			StrafeRight();
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
	*/

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
		else if (direction == left)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
		}
		else if (direction == right)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
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
			Transform spawn = weap.transform.FindDeepChild(name);
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
			GameObject clone = Instantiate(Bullet, spawn.position, Quaternion.identity);
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
		animator.SetBool("ACS_Dead1", true);
	}
	public void Dead2()
	{
		animator.SetBool("ACS_Dead2", true);
	}
	public void Dead3()
	{
		animator.SetBool("ACS_Dead3", true);
	}
	public void Dead4()
	{
		animator.SetBool("ACS_Dead4", true);
	}
	public void StrafeLeft()
	{
		animator.SetBool("ACS_StrafeLeft", true);
		animator.speed = animator.speed * speed;
		direction = left;
	}
	public void StrafeRight()
	{
		animator.SetBool("ACS_StrafeRight", true);
		animator.speed = animator.speed * speed;
		direction = right;
	}
	public void Idle()
	{
		animator.SetBool("ACS_Idle2", true);
		animator.speed = 1;
		direction = 0;
		roat = 0;
	}
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
	public void ChangeToWalk()
	{
		animator.SetBool("ACS_ChangeToWalk", true);
	}
	public void ChangeToWeels()
	{
		animator.SetBool("ACS_ChangeToWeels", true);
	}
	public void MoveWeelsForwad()
	{
		animator.SetBool("ACS_MoveWeelsForwad", true);
		animator.speed = animator.speed * speed;
		direction = forward;
	}
	public void MoveWeelsBack()
	{
		animator.SetBool("ACS_MoveWeelsBack", true);
		animator.speed = animator.speed * speed;
		direction = backward;
	}
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
}
