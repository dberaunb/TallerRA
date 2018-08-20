using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	
	
	// Update is called once per frame
	public void CargarEscenario() {

        SceneManager.LoadScene("AgregarObjetos");
    }

    public void Salir()
    {

        SceneManager.LoadScene("Intro");
    }

    public void CerrarApp()
    {

        Application.Quit();
    }

}

