﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giroscopio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        transform.rotation = GyroToUnity(Input.gyro.attitude);

    }

        private static Quaternion GyroToUnity(Quaternion q)
    {

        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}