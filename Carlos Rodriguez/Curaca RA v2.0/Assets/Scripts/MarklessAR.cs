using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarklessAR : MonoBehaviour {
    private Gyroscope gyro;
    private GameObject cameraContainer;
    private Quaternion rot;



    private WebCamTexture backCam;
    public RawImage background;
    public AspectRatioFitter fit;

    private bool arReady = false;


    // Use this for initialization
    void Start () {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("This device does not have Gyroscope");
            return;
        }

        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (!WebCamTexture.devices[i].isFrontFacing)
            {
                backCam = new WebCamTexture(WebCamTexture.devices[i].name, Screen.width, Screen.height);
                break;
            }
        }

        if (backCam == null)
        {
            Debug.Log("This device does not have BackCamera");
            return;
        }

        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        gyro = Input.gyro;
        gyro.enabled = true;
        cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0);
        rot = new Quaternion(0, 0, 1, 0);


        backCam.Play();
        background.texture = backCam;

        arReady = true;
    }

    // Update is called once per frame
    void Update () {
        if (arReady)
        {
            float ratio = (float)backCam.width / (float)backCam.height;
            fit.aspectRatio = ratio;

            float scaleY = backCam.videoVerticallyMirrored ? -1f : 1f;
            background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

            int orient = -backCam.videoRotationAngle;
            background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

            transform.localRotation = gyro.attitude * rot;
        }
    }
}
