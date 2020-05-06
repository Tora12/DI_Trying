using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] public float JumpPower = 10f; 
    [SerializeField] public float MoveSpeedMultiplier = 1f;
    [SerializeField] float AirSpeed = 6f;
    [SerializeField] public float dashSpeed = 24f;
	[SerializeField] float dashDistance = 6f;
	[SerializeField] float dashRecharge = 1f;
	[SerializeField] float grappleSpeed = 6f;
	[SerializeField] float grappleRange = 7f;
	[Range(1f, 4f)][SerializeField] float GravityMultiplier = 2f;
    [SerializeField] float AnimSpeedMultiplier = 1f;
    [SerializeField] float GroundCheckDistance = 0.2f;
	[SerializeField] float MovingTurnSpeed = 720;
    [SerializeField] float StationaryTurnSpeed = 720;
	[SerializeField] float RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others


    Rigidbody rigidBody;
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
	
    bool canDoubleJump=true;
	bool airJump=true;
	
    bool canDash=true;
    bool dashing=false;
	float lastDashTime=0;
	bool airDash=false;
	bool dashJump=false;
    Vector3 dashDirection;
	
    public bool canUseGrapple=true;
    GameObject Hook;


    void Start()
    {
        Animator = GetComponent<Animator>();
	rigidBody = GetComponent<Rigidbody>();
	Capsule = GetComponent<CapsuleCollider>();
	CapsuleHeight = Capsule.height;
	CapsuleCenter = Capsule.center;
	rigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX; 
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
        if(canUseGrapple && (GameObject.FindGameObjectsWithTag("Grapple").Length == 1)){
			Hook = GameObject.FindGameObjectWithTag("Grapple");
			Vector3 point= -transform.position + Hook.transform.position;
			if(point.magnitude<grappleRange){
				HandleGrappleMovement();
			}
		}
    }
    void UpdateAnimator(Vector3 move){
		Animator.SetFloat("Forward", ForwardAmount, 0.1f, Time.deltaTime);
		Animator.SetFloat("Turn", TurnAmount, 0.1f, Time.deltaTime);
		Animator.SetBool("Crouch", false);
		Animator.SetBool("OnGround", IsGrounded);
		if (!IsGrounded){
			Animator.SetFloat("Jump", rigidBody.velocity.y);
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
		v.y = rigidBody.velocity.y;
		rigidBody.velocity = v;
	} 
    }
    void HandleAirMovement(Vector3 move, bool jump){
       Vector3 extraGravityForce=(Physics.gravity * GravityMultiplier)-Physics.gravity;
       rigidBody.AddForce(extraGravityForce);
       GroundCheckDistance=rigidBody.velocity.y<0?OrigGroundCheckDistance:0.01f;
       Vector3 movementForce=(move*AirSpeed);
       //rigidBody.AddForce(movementForce);
       movementForce.y=rigidBody.velocity.y;
       rigidBody.velocity=movementForce;
       if(jump && ((canDoubleJump && airJump) ||(canDash && dashJump))){
            rigidBody.velocity=new Vector3(rigidBody.velocity.x,JumpPower,rigidBody.velocity.z);
            if(dashJump) dashJump=false;
			else airJump=false;
        }
    }
    void HandleGroundMovement(bool jump){
        if(jump&& Animator.GetCurrentAnimatorStateInfo(0).IsName("Grounded")){
            rigidBody.velocity=new Vector3(rigidBody.velocity.x,JumpPower,rigidBody.velocity.z);
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
            
        }else if (abillity=="Nothing"){
            canDoubleJump=false;
			canDash=false;
			canUseGrapple=false;
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
            rigidBody.velocity=dashDirection;
            //ApplyExtraTurnRotation();
            //Animator.SetFloat("Forward", ForwardAmount, 0.1f, Time.deltaTime);
	        //Animator.SetFloat("Turn", TurnAmount, 0.1f, Time.deltaTime);
	        //Animator.SetBool("Crouch", false);
	        Animator.SetBool("OnGround", false);
			if(Time.time-lastDashTime>dashDistance/dashSpeed){
				dashing=false;
				rigidBody.velocity=Vector3.zero;
				dashJump=true;
			}
        }
	}
	void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
			
            if(contact.normal.y<.5f){
				dashing=false;
			}
        }
        
    }
	void HandleGrappleMovement(){
		Vector3 point=-transform.position + Hook.transform.position;
		if(point.magnitude<2f){
			Destroy(Hook);
		}
		Animator.SetBool("OnGround", false);
		point.Normalize();
		point*=grappleSpeed;
		rigidBody.velocity= point + rigidBody.velocity -rigidBody.velocity.y*Vector3.up;

	}
}