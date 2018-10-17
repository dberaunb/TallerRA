using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer : MonoBehaviour {
    public GameObject button;
    public GameObject objeto;
    public AudioSource As;
  

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
		if(As.clip.length - 0.05 >= 0.25)
        {
        
            objeto.SetActive(true);
        }

        if(As.isPlaying == false)
        {
            button.SetActive(true);
        }
	}
}
