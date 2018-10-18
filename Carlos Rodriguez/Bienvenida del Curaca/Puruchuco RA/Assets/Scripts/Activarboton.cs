using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarboton : MonoBehaviour {
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject mapa;


    private void Start()
    {
        btn2.SetActive(false);
        btn3.SetActive(false);
    }



    public void ActivarMapa()
    {
        btn1.SetActive(false);
        btn2.SetActive(true);
        
    }

    public void cambioBoton()
    {
        GPS.Instance.RawEnabled = true;
        mapa.SetActive(true);
        btn3.SetActive(true);
        btn2.SetActive(false);
    }

    public void botoncambio()
    {
        GPS.Instance.RawEnabled = false;
        mapa.SetActive(false);
        btn2.SetActive(true);
        btn3.SetActive(false);
    }
}
