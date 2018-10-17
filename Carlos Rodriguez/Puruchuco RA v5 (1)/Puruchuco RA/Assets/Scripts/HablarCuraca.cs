using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HablarCuraca : MonoBehaviour {

    public AudioSource Hcuraca1;
    public GameObject curaca2;
    public Animator curaca;
    public GameObject objeto;
    public GameObject button;
   

	// Use this for initialization
	void Start () {
        curaca = GetComponent<Animator>();
        curaca2.SetActive(false);
        objeto.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

     
        if (Hcuraca1.isPlaying)
        {
            curaca.SetBool("isTalking", true);
            curaca2.SetActive(false);

        } else if(Hcuraca1.isPlaying == false)
        {
            curaca2.SetActive(true);
            
        } 
       
        if(objeto.activeInHierarchy == true)
        {
            curaca.SetBool("isTalking", false);
            button.SetActive(true);


        }
	}
}
