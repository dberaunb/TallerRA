using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer : MonoBehaviour {
    public GameObject button;
    public AudioSource As;
    public GameObject curaca1;
    public GameObject curaca2;
   

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	

       if(As.isPlaying == false)
        {
            button.SetActive(true);

        }

        Invoke("AparecerCuraca", 25.0f);

      
	}


    public void AparecerCuraca()
    {
        curaca1.SetActive(false);
        curaca2.SetActive(true);
    }

}
