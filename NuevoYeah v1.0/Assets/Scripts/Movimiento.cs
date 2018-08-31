using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
    public Animator an;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb =  GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        
        //an.transform.position = an.transform.position + an.transform.forward;
        
        
	}
}
