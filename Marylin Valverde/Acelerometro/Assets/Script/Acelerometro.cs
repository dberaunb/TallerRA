using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerometro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vector3 = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);

        transform.Translate(vector3 * Time.deltaTime);
	}
}
