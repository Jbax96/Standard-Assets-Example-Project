using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour {

    public Camera FPCam;
    public Camera TDCam;
    public Camera ShoulderCam;


	void Start () {
        FPCam.enabled = false;
        TDCam.enabled = true;
        ShoulderCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            FPCam.enabled = true;
            TDCam.enabled = true;
            ShoulderCam.enabled = false;
        }
        else if (Input.GetKeyDown("2"))
        {
            FPCam.enabled = false;
            TDCam.enabled = true;
            ShoulderCam.enabled = false;
        }
        else if (Input.GetKeyDown("3"))
        {
            FPCam.enabled = false;
            TDCam.enabled = false;
            ShoulderCam.enabled = true;
        }
    }
}
