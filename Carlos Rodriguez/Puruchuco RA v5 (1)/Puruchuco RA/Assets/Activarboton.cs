using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activarboton : MonoBehaviour {
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;

	 public void ActivarMapa()
    {
        btn2.SetActive(true);
        btn1.SetActive(false);
    }

    public void cambioBoton()
    {
        GPS.Instance.RawEnabled = true;
        btn3.SetActive(true);
        btn2.SetActive(false);
    }

    public void botoncambio()
    {
        GPS.Instance.RawEnabled = false;
        btn2.SetActive(true);
        btn3.SetActive(false);
    }
}
