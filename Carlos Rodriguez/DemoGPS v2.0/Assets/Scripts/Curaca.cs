using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curaca : MonoBehaviour {
    public GameObject curaca;
    public AudioSource As;
    Animator an;
	// Use this for initialization
	void Start () {
        an = GetComponent<Animator>();
        As.Play();
        

        
	}
	
	// Update is called once per frame
	void Update () {
        
        if (As.isPlaying)
        {
            an.SetBool("isTalking",true);
        }
        else
        {
            an.SetBool("isTalking", false);
        }
	}
}
