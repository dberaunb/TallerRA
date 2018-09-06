using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour {
    public static WP_Actor instance { get; set; }
    public AudioSource Hablar;
    public AudioSource Caminar;
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
            Hablar.Play();
            Caminar.Stop();
            
        }
    }

     
}
