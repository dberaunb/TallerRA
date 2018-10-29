using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCuraca : MonoBehaviour {

    public Vector3[] Posiciones;
    private Vector3 siguientePosicion;

    public bool ultimaPosicion = false;
    public Vector3 MirarAlFrente;

    public GameObject canvas;

    public GameObject Curaca;
    private void Start()
    {
        transform.position = Posiciones[0];
        transform.LookAt(Posiciones[1]);
        siguientePosicion = Posiciones[1];
        canvas.SetActive(false);
    }

    void Update () {
        if((transform.position.x < siguientePosicion.x + 0.1) && (transform.position.x > siguientePosicion.x - 0.1) && (transform.position.y < siguientePosicion.y + 0.1) && (transform.position.y > siguientePosicion.y - 0.1) && (transform.position.z < siguientePosicion.z + 0.1) && (transform.position.z > siguientePosicion.z - 0.1))
        {
            if(!ultimaPosicion)
                CambiarSiguientePosicion();
            else
            {
                transform.LookAt(MirarAlFrente);
                Curaca.GetComponent<Animator>().SetBool("Hablar", true);
                Curaca.GetComponent<AudioSource>().enabled = true;
                canvas.SetActive(true);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime);

        }
	}

    private void CambiarSiguientePosicion()
    {
        for (int i = 0; i < Posiciones.Length - 1; i++)
        {
            if (siguientePosicion == Posiciones[i])
            {
                siguientePosicion = Posiciones[i + 1];
                if (i + 1 == Posiciones.Length - 1)
                    ultimaPosicion = true;
                transform.LookAt(siguientePosicion);
                break;
            }
        }
    }
}
