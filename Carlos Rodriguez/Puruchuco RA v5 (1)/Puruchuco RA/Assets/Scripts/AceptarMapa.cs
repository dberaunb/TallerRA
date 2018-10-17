using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AceptarMapa : MonoBehaviour {

    public GameObject canvas;

    public GameObject map;

    public GameObject GUImap;
    public GameObject GUIactivemap;

    public Sprite[] sprites;

    public void ActiveCanvas(bool stt)
    {
        canvas.SetActive(stt);
    }

    public void TomarMapa()
    {
        GUImap.GetComponent<Image>().sprite = sprites[1];
        GUIactivemap.GetComponent<Image>().sprite = sprites[0];
        map.SetActive(false);
    }
}
