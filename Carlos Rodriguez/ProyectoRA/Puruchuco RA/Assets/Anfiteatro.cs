using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anfiteatro : MonoBehaviour {

    //Textos
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public Animator curaca;
    public AudioSource vozCuraca;

    // Use this for initialization
    void Start () {
        curaca = GetComponent<Animator>();
        
        //Textos
        texto2.SetActive(false);
        texto3.SetActive(false);
        texto4.SetActive(false);
        
    }
	
	// Update is called once per frame
	void Update () {
        Invoke("CambiarTexto", 7.0f);
        if (vozCuraca.isPlaying)
        {
            curaca.SetBool("Hablando", true);
        }
    }


    public void CambiarTexto()
    {
        texto1.SetActive(false);
        texto2.SetActive(true);
        Invoke("CambiarTexto2", 10.0f);

    }

    public void CambiarTexto2()
    {
        texto2.SetActive(false);
        texto3.SetActive(true);
        Invoke("CambiarTexto3", 10.0f);

    }
    public void CambiarTexto3()
    {
        texto3.SetActive(false);
        texto4.SetActive(true);

    }
  
}
