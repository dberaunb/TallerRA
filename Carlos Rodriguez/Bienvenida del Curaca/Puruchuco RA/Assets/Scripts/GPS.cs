using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GPS : MonoBehaviour
{
    //Mapa
    public bool activated = false;
    public bool RawEnabled = false;

    int zoom = 25;
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

    public RawImage img;
    string url;
    public GameObject rw;



    //GPS
    public static GPS Instance { set; get; }
    public float latitude;
    public float longitude;
   
    private bool isGPSReady;

    

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        rw.SetActive(false);
      
        StartCoroutine(StartLocationService());
    }

    private void Update()
    {
        if (isGPSReady == true)
        {
            Input.location.Start();
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }
       

     

        if (activated == true && RawEnabled == true)
        {
            StartCoroutine(Map());
        }
        else if (RawEnabled)
        {
            StopCoroutine(Map());
        }

    }

  

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            isGPSReady = false;
            activated = false;
            yield break;
        }

       

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }
        else {

            isGPSReady = true;
            activated = true;

        }

        
        yield break;
    }


    IEnumerator Map()
    {

        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + latitude + "," + longitude +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:Yo%7C" + latitude + "," + longitude + "&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBEXlM7t_dyPJilVoLfD12nSvjMBSn0oqM";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
}