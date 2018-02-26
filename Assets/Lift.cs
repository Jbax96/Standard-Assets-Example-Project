using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

    private Vector3 startPosition;
    private Vector3 currentPosition;

    public int speed = 3;
    public int maxDistance;

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * speed));
        transform.position = currentPosition;
	}
}
