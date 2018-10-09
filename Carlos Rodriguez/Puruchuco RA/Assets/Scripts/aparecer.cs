using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aparecer : MonoBehaviour {
    public GameObject cubo;
    public AudioSource As;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(As.isPlaying == false)
        {
            cubo.SetActive(true);
        }
	}
}
