using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour {
    private Gyroscope gyro;
    private bool gyroSupported;
    private Quaternion rotfix;

    [SerializeField]
    private Transform worldobj;
    private float starY;


    // Use this for initialization
    void Start () {
        gyroSupported = SystemInfo.supportsGyroscope;

        GameObject camParent = new GameObject("camParent");
        camParent.transform.position = transform.position;
        transform.parent = camParent.transform;

        
        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
        camParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
        rotfix = new Quaternion(0, 0, 1, 0);
        
	}
	
	// Update is called once per frame
	void Update () {

        if(gyroSupported && starY == 0)
        {
            ResetGyroRotation();
        }

        transform.localRotation = gyro.attitude*rotfix;
	}

   public  void ResetGyroRotation()
    {
        starY = transform.eulerAngles.y;
        worldobj.rotation = Quaternion.Euler(0f, starY, 0f);
    }
}
