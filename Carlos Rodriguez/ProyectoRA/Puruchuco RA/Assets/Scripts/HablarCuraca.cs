using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HablarCuraca : MonoBehaviour {

    public AudioSource Hcuraca1;
    public GameObject curaca2;
    public Animator curaca;
    public GameObject curMapa;
    public GameObject button;
    public GameObject button2;




    //Textos
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public GameObject texto5;

	// Use this for initialization
	void Start () {
        curaca = GetComponent<Animator>();
        curaca2.SetActive(false);
        curMapa.SetActive(false);
        button.SetActive(false);


        //Textos
        texto2.SetActive(false);
        texto3.SetActive(false);
        texto4.SetActive(false);
        texto5.SetActive(false);
        
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
            curaca.SetBool("isTalking", false);

        } 

        if(button2.activeInHierarchy == true)
        {
            button.SetActive(false);
        }
        Invoke("CambiarTexto", 7.0f);




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
        Invoke("CambiarTexto4", 10.0f);

    }
    public void CambiarTexto4()
    {
        texto4.SetActive(false);
        texto5.SetActive(true);
    }
}
