using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Userinput : MonoBehaviour
{
    
    private PlayerMovement character;
    private Transform cameraPos;
    private Vector3 move;
    private bool jump;
    private bool dash;
	private bool grapple;
    void Start()
    {
        if(Camera.main!=null)cameraPos=Camera.main.transform;
        else Debug.LogWarning("No Main Camera",gameObject);
        character=GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        if(!jump)jump=Input.GetButtonDown("Jump");
        if(!dash)dash=Input.GetButtonDown("Fire3");
		if(!grapple)grapple=Input.GetButtonDown("Fire4");
    }
    void FixedUpdate(){
        float h =Input.GetAxis("Horizontal");
        move=h*cameraPos.right;
        character.Move(move,jump,dash);
		if(grapple==true && character.canUseGrapple==true)Drone.Instance.grapple();
        jump=false;
        dash=false;
		grapple=false;
    }   
}
