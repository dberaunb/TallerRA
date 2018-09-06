using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour {

    
    public AudioClip clip;
    public AudioSource source;

	// Use this for initialization
	void Start () {
        source.clip = clip;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
            source.Play();

        }

        
	}
}
