using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour {
    public AudioSource AS;
    Animator an;
    float speed = 0.5f;
    public Transform target;
    

	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            speed = 0;
            an.SetBool("isIdle", true);
            AS.Play();
            
        }
    }

     
}
