using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Time.deltaTime * Input.GetAxis("Vertical"));

        Quaternion quaternion = Quaternion.Euler(0, 90 * Input.GetAxis("Horizontal") * Time.deltaTime, 0);

        GetComponent<Rigidbody>().MoveRotation(transform.rotation * quaternion);

        
    }
}
