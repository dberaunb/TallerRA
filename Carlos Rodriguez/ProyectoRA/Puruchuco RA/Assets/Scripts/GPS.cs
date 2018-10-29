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

    int zoom = 19;
    public int mapWidth = 680;
    public int mapHeight = 680;

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
        if (isGPSReady == true && RawEnabled == false)
        {
            Input.location.Start();
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }
       

     

        if (activated == true && RawEnabled == true)
        {
            Input.location.Stop();
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

        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + "-12.04940"  + "," + "-76.93608" +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale
            + "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:Yo%7C" + latitude + "," + longitude + "&markers=color:green%7Clabel:1%7C-12.04967,-76.93633&markers=color:green%7Clabel:2%7C-12.04959,-76.93613,&markers=color:green%7Clabel:3%7C-12.04963,-76.93589,&markers=color:green%7Clabel:4%7C-12.04976,-76.93591,&markers=color:green%7Clabel:5%7C-12.04950,-76.93590&key=AIzaSyBEXlM7t_dyPJilVoLfD12nSvjMBSn0oqM";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
}