using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controladorcamara : MonoBehaviour {

    public GameObject jugador;
    private Vector3 positionrelative;

	// Use this for initialization
	void Start () {
        positionrelative =  transform.position - jugador.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = jugador.transform.position + positionrelative;

	}
}
