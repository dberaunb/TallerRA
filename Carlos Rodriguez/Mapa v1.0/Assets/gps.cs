using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gps : MonoBehaviour
{ 
    public static gps instance { get; set; }

    public RawImage img;
    string url;
    public GameObject rw;

    public float latitude;
    public float longitude;
    public bool activated = false;
    public bool RawEnabled = false;

    int zoom = 25;
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;


    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocation());
        rw.SetActive(false);
        
    }

    IEnumerator StartLocation()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Gps service is not enabled in this device");
            yield break;
        }
        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            latitude =  Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            activated = true;
            yield break;
        }
    }

    private void Update()
    {
        
        if(activated == true && RawEnabled == true)
        {
            StartCoroutine(Map());
        }
        else if(RawEnabled)
        {
            StopCoroutine(Map());
        }   
    }



    IEnumerator Map()
    {
        
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale  
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C"+latitude+","+longitude+"&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBEXlM7t_dyPJilVoLfD12nSvjMBSn0oqM";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
}


