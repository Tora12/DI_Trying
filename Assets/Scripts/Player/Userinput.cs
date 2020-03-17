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
    void Start()
    {
        if(Camera.main!=null)cameraPos=Camera.main.transform;
        else Debug.LogWarning("No Main Camera",gameObject);
        character=GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        if(!jump)jump=Input.GetButtonDown("Jump");
        if(!dash)dash=Input.GetButton("Fire3");
    }
    void FixedUpdate(){
        float h =Input.GetAxis("Horizontal");
        move=h*cameraPos.right;
        character.Move(move,jump,dash);
        jump=false;
        dash=false;
    }   
}
