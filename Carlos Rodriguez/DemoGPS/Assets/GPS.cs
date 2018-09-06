using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class GPS : MonoBehaviour
{


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
        referenceLatitude = -12.10633;
        referenceLongitude = -77.00124;
        referenceDistance = 0.00020;
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

        isGPSReady = true;
        yield break;
    }
}