using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class AutoCannon : MonoBehaviour
{
    public GameObject[] weapArray;

    private Animator animator, animatorWeap;
	private Rigidbody rb;
	[SerializeField] private float speed = 1.0f;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
		rb = GetComponentInChildren<Rigidbody>();
    }

	void FixedUpdate()
	{
		if (Input.GetKey("j"))
        {
			WalkForwad();
        }
	}

	public void Fire()
	{
		foreach (GameObject weap in weapArray)
		{
			animatorWeap = weap.GetComponent<Animator>();
			animatorWeap.SetBool("Fire", true);
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
		transform.Translate(-Vector3.right * Time.deltaTime * speed, Space.Self);
		animator.SetBool("ACS_StrafeLeft", true);
	}
	public void StrafeRight()
	{
		transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
		animator.SetBool("ACS_StrafeRight", true);
	}
	public void Idle()
	{
		animator.SetBool("ACS_Idle", true);
	}
	public void Idle2()
	{
		animator.SetBool("ACS_Idle2", true);
	}
	public void Attack()
	{
		animator.SetBool("ACS_Attack", true);
	}
	public void TurnLeft()
	{
		animator.SetBool("ACS_TurnLeft", true);
	}
	public void TurnRight()
	{
		animator.SetBool("ACS_TurnRight", true);
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
	}
	public void MoveWeelsForwad2()
	{
		animator.SetBool("ACS_MoveWeelsForwad2", true);
	}
	public void MoveWeelsBack()
	{
		animator.SetBool("ACS_MoveWeelsBack", true);
	}
	public void WalkForwad()
	{
		animator.SetBool("ACS_WalkForwad", true);
		transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
	}
	public void WalkForwad2()
	{
		transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
		animator.SetBool("ACS_WalkForwad2", true);
	}
	public void WalkBack()
	{
		animator.SetBool("ACS_WalkBack", true);
	}
}
