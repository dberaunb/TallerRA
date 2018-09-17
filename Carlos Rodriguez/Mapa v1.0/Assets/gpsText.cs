using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gpsText : MonoBehaviour {



    public Text coordinates;



	void Update () {


        coordinates.text = "Lat:  " + gps.instance.latitude.ToString() + "     Lon:" + gps.instance.longitude;
	}
}
