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

    public GameObject obj;
    public Text coordinates;
    public Text referenceCoordinates;
    public Text distanceFrom3dModel;

    private double referenceLatitude;
    private double referenceLongitude;
    private double referenceDistance;
    private bool isGPSReady;

    private double distFrom3dModel_lat;
    private double distFrom3dModel_lon;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        obj.SetActive(false);
        rw.SetActive(false);
        referenceLatitude = -12.10637;
        referenceLongitude = -77.00125;
        referenceDistance = 0.00010;
        distFrom3dModel_lat = 0;
        distFrom3dModel_lon = 0;
        distanceFrom3dModel.text = "Distance (Lan,Lon): 0 - 0 ";
        referenceCoordinates.text = "Reference (Lat,Lon): " + referenceLatitude.ToString() + " - " + referenceLongitude.ToString();
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
       

        coordinates.text = "Current (Lat,Lon): " + GPS.Instance.latitude.ToString() + " - " + GPS.Instance.longitude.ToString();
        if (CloseEnoughForMe(Instance.latitude, referenceLatitude, referenceDistance) && CloseEnoughForMe(Instance.longitude, referenceLongitude, referenceDistance))
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
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

    private bool CloseEnoughForMe(double value1, double value2, double acceptableDifference)
    {
        distanceFrom3dModel.text = "Distance (Lan,Lon): " + Math.Abs(value1 - value2).ToString();
        return Math.Abs(value1 - value2) <= acceptableDifference;
    }

    private double distanceBetweenTwoPoints(double value1, double value2)
    {
        return Math.Abs(value1 - value2);
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
            "&markers=color:blue%7Clabel:S%7C" + latitude + "," + longitude + "&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyBEXlM7t_dyPJilVoLfD12nSvjMBSn0oqM";
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();

    }
}