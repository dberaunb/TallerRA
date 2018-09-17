using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonCuraca : MonoBehaviour {

    public GameObject btn;
    public GameObject btn2;


	// Use this for initialization
	void Start () {

        btn.SetActive(false);
        btn2.SetActive(false);
	}
	


	public void PlayBoton() {

        Curaca.instance.btnclicked = true;
        btn2.SetActive(true);

	}
}
