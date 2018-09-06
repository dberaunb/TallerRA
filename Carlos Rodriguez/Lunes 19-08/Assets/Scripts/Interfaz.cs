using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {

    public GameObject prefab;
    

    public void Boton()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    
}
