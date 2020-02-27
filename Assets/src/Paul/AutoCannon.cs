using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]

public class AutoCannon : MonoBehaviour
{
    public GameObject[] weapArray;

    private Animator animator, animatorWeap;
	private Rigidbody rb;
	private Transform startMarker;
	private Transform endMarker;
	[SerializeField] private float speed = 1.0f;

    void Awake()
    {
        animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
    }

	/*
	void FixedUpdate()
    {
		// Distance moved equals elapsed time times speed..
		float distCovered = (Time.time - startTime) * speed;

		// Fraction of journey completed equals current distance divided by total distance.
		float fractionOfJourney = distCovered / journeyLength;

		// Set our position as a fraction of the distance between the markers.
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
	}
	*/

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
		//rb.velocity = -transform.right * speed;
		//tansform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
		animator.SetBool("ACS_StrafeLeft", true);
	}

	public void OnAnimatorMove()
	{
		// we implement this function to override the default root motion.
		// this allows us to modify the positional speed before it's applied.
		if (Time.deltaTime > 0)
		{
			Vector3 v = (animator.deltaPosition * speed) / Time.deltaTime;

			// we preserve the existing y part of the current velocity.
			v.y = rb.velocity.y;
			rb.velocity = v;
		}
	}
	public void StrafeRight()
	{
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
	}
	public void WalkForwad2()
	{
		animator.SetBool("ACS_WalkForwad2", true);
	}
	public void WalkBack()
	{
		animator.SetBool("ACS_WalkBack", true);
	}
}
