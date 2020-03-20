﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MovingTurnSpeed = 720;
    [SerializeField] float StationaryTurnSpeed = 720;
    [SerializeField] float JumpPower = 10f;
    [Range(1f, 4f)][SerializeField] float GravityMultiplier = 2f;
    [SerializeField] float RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
    [SerializeField] float MoveSpeedMultiplier = 1f;
    [SerializeField] float AirSpeed = 6f;
    [SerializeField] float dashSpeed = 24f;
	[SerializeField] float dashDistance = 6f;
	[SerializeField] float dashRecharge = 1f;
    [SerializeField] float AnimSpeedMultiplier = 1f;
    [SerializeField] float GroundCheckDistance = 0.2f;


    Rigidbody rigidbody;
    Animator Animator;
    bool IsGrounded;
    float OrigGroundCheckDistance;
    const float k_Half = 0.5f;
    float TurnAmount;
    float ForwardAmount;
    Vector3 GroundNormal;
    float CapsuleHeight;
    Vector3 CapsuleCenter;
    CapsuleCollider Capsule;
    bool canDoubleJump=false;
    bool canDash=true;
    bool dashing=false;
	float lastDashTime=0;
	bool airDash=false;
	bool dashJump=false;
    Vector3 dashDirection;
    bool canUseGrapple=false;
    bool airJump=true;


    void Start()
    {
        Animator = GetComponent<Animator>();
	rigidbody = GetComponent<Rigidbody>();
	Capsule = GetComponent<CapsuleCollider>();
	CapsuleHeight = Capsule.height;
	CapsuleCenter = Capsule.center;
	rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX; 
	OrigGroundCheckDistance = GroundCheckDistance;
    }

    public void Move(Vector3 move,bool jump, bool dash){
        if(move.magnitude>1f)move.Normalize();
        Vector3 tempmove=move;
        move=transform.InverseTransformDirection(move);
        CheckGroundStatus();
        move = Vector3.ProjectOnPlane(move,GroundNormal);
        TurnAmount=Mathf.Atan2(move.x,move.z);
        ForwardAmount=move.z;
        if((dash&&canDash) || dashing){
            HandleDashMovement(tempmove);
        }else{
            ApplyExtraTurnRotation();
            if(IsGrounded){
                HandleGroundMovement(jump);
            }else{
                HandleAirMovement(tempmove,jump);
            }
            UpdateAnimator(move);
        }
        
    }
    void UpdateAnimator(Vector3 move){
	Animator.SetFloat("Forward", ForwardAmount, 0.1f, Time.deltaTime);
	Animator.SetFloat("Turn", TurnAmount, 0.1f, Time.deltaTime);
	Animator.SetBool("Crouch", false);
	Animator.SetBool("OnGround", IsGrounded);
	if (!IsGrounded){
		Animator.SetFloat("Jump", rigidbody.velocity.y);
	}
	float runCycle =Mathf.Repeat(Animator.GetCurrentAnimatorStateInfo(0).normalizedTime + RunCycleLegOffset, 1);
	float jumpLeg = (runCycle < k_Half ? 1 : -1) * ForwardAmount;		
	if (IsGrounded){
		Animator.SetFloat("JumpLeg", jumpLeg);
	}
	if (IsGrounded && move.magnitude > 0){
		Animator.speed = AnimSpeedMultiplier;
	}else{
		Animator.speed = 1;
	}
    }
    void ApplyExtraTurnRotation(){
	float turnSpeed = Mathf.Lerp(StationaryTurnSpeed, MovingTurnSpeed, ForwardAmount);
	transform.Rotate(0, TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
    public void OnAnimatorMove(){
	if (IsGrounded && Time.deltaTime > 0){
		Vector3 v = (Animator.deltaPosition * MoveSpeedMultiplier) / Time.deltaTime;
		v.y = rigidbody.velocity.y;
		rigidbody.velocity = v;
	}
    }
    void HandleAirMovement(Vector3 move, bool jump){
       Vector3 extraGravityForce=(Physics.gravity * GravityMultiplier)-Physics.gravity;
       rigidbody.AddForce(extraGravityForce);
       GroundCheckDistance=rigidbody.velocity.y<0?OrigGroundCheckDistance:0.01f;
       Vector3 movementForce=(move*AirSpeed);
       //rigidbody.AddForce(movementForce);
       movementForce.y=rigidbody.velocity.y;
       rigidbody.velocity=movementForce;
       if(jump && ((canDoubleJump && airJump) ||(canDash && dashJump))){
            rigidbody.velocity=new Vector3(rigidbody.velocity.x,JumpPower,rigidbody.velocity.z);
            if(airJump) airJump=false;
			else dashJump=false;
        }
    }
    void HandleGroundMovement(bool jump){
        if(jump&& Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded")){
            rigidbody.velocity=new Vector3(rigidbody.velocity.x,JumpPower,rigidbody.velocity.z);
            IsGrounded=false;
            airJump=true;
			airDash=true;
			dashJump=false;
            GroundCheckDistance=0.1f;
        }
    }
    void CheckGroundStatus(){
        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position+(Vector3.up*0.1f),Vector3.down,out hitInfo,GroundCheckDistance)){
            GroundNormal=hitInfo.normal;
            IsGrounded=true;
            Animator.applyRootMotion=true;
        }else{
            IsGrounded=false;
            GroundNormal=Vector3.up;
            Animator.applyRootMotion=false;
    	}
    }
    public void UnlockMovementAbillity(string abillity){
        if(abillity=="DoubleJump"){
            canDoubleJump=true;
        }else if (abillity=="Dash"){
            canDash=true;
        }else if (abillity=="GrappleHook"){
            canUseGrapple=true;
        }else if (abillity=="TBA"){
            
        }
    }
	void HandleDashMovement(Vector3 move ){
		if(!dashing && (Time.time-lastDashTime>dashRecharge) && (IsGrounded || airDash)){
			move.Normalize();
			if(move==Vector3.zero)move=new Vector3(0,0,1);
            dashDirection=(move * dashSpeed);
            dashDirection.y=0f;
			dashing=true;
			airDash=false;
			lastDashTime=Time.time;
        }
		if(dashing){
            rigidbody.velocity=dashDirection;
            //ApplyExtraTurnRotation();
            //Animator.SetFloat("Forward", ForwardAmount, 0.1f, Time.deltaTime);
	        //Animator.SetFloat("Turn", TurnAmount, 0.1f, Time.deltaTime);
	        //Animator.SetBool("Crouch", false);
	        Animator.SetBool("OnGround", false);
			if(Time.time-lastDashTime>dashDistance/dashSpeed){
				dashing=false;
				rigidbody.velocity=Vector3.zero;
				dashJump=true;
			}
        }
	}
}