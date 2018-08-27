using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour {


    int contador;
    Rigidbody rb;
    public float velocidad;
    public Text puntuacion;
    public Text finish;

   

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        contador = contador - 1;
        actualizarmarcador();

    }

    private void actualizarmarcador()
    {
        puntuacion.text = "Cuyes:  " + contador;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        contador = 2;
        actualizarmarcador();
        finish.gameObject.SetActive(false);
    }

    // Use this for initialization


    // Update is called once per frame

    void FixedUpdate () {

        float MoverHorizontal = Input.GetAxis("Horizontal");
        float MoverVertical = Input.GetAxis("Vertical");

       Vector3 Movimiento = new Vector3(MoverHorizontal, 0.0f, MoverVertical);

       rb.AddForce(Movimiento * velocidad * Time.deltaTime);   

   }
}
