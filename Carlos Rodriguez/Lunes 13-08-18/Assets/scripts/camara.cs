using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour {

    public Animator an;
    private Vector3 positionrelative;

	// Use this for initialization
	void Start () {
        positionrelative = transform.position - an.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = an.transform.position + positionrelative;
	}
}
