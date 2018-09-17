using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boton : MonoBehaviour {

    public GameObject rw;
    public GameObject btn1;
    public GameObject btn2;


   




    public void Activar () {

        rw.SetActive(true);
        GPS.Instance.RawEnabled = true;
        btn1.SetActive(false);
        btn2.SetActive(true);

	}

    public void Desactivar()
    {
        rw.SetActive(false);
        GPS.Instance.RawEnabled = false;
        btn1.SetActive(true);
        btn2.SetActive(false);
    }
}
