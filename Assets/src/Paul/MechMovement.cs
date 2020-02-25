using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechMovement : MonoBehaviour
{
    [SerializeField] float rootMotionOffsetWalk = 5.2f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
        {
            animator.SetTrigger("Walk");
            transform.Translate(new Vector3(0, 0, rootMotionOffsetWalk/500));
        }
        
    }

}


