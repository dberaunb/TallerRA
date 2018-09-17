using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curaca : MonoBehaviour {

    public static Curaca instance { get; set; }
    public GameObject btn;
    public bool finish = false;
    public bool btnclicked = false;
    public AudioSource As;
    public Animator an;
	// Use this for initialization
	void Start () {
        instance = this;
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
            finish = true;
        }

        if(finish == true)
        {
            if(btnclicked == false)
            {
                btn.SetActive(true);

            } else if ( btnclicked == true)
            {
                btn.SetActive(false);
            }
        }

        
	}
}
