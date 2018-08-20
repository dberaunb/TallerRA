using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.CrossPlatformInput;

public class Correr : MonoBehaviour {
    Animator animator;
    public float speed;
    Vector3 MoveVector;
    float directionx;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator> ();
        rb = GetComponent<Rigidbody>();

	}

    // Update is called once per frame
    void Update()
    {


        transform.Translate(0, 0, 0.1f);

        if (Input.GetKey(KeyCode.W)) { 
 
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);

        }
        else if (Input.GetKey(KeyCode.S)) {

            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);

        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }


       

    }
    
    
    



}
