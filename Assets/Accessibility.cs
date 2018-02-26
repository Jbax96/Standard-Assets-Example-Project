using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Accessibility : MonoBehaviour {

    public float fullSpeed = 1;
    public float slowSpeed = 0.3f;

    private bool isSlow;
    // Use this for initialization
    void Start() {
        Time.timeScale = fullSpeed;
    }
	
	// Update is called once per frame
	void Update () {

        //Reduce Game Speed
        if (Input.GetKeyDown(KeyCode.Q))
            Time.timeScale = slowSpeed;
        }
	}

