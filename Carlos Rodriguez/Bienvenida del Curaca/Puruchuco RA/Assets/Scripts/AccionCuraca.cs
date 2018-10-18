using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionCuraca : MonoBehaviour {

    public GameObject ControllerMap;
    public GameObject map;

    public void ActivarMapa()
    {
        ControllerMap.GetComponent<AceptarMapa>().ActiveCanvas(true);
    }

    public void ActivarObjMapa()
    {
        map.SetActive(true);
    }
}
