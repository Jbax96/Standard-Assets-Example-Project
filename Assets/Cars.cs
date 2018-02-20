using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour {
    public int currentWaypoint;
    public int currentLap;
    public Transform lastWaypoint;
    public int nbWaypoint;

    private static int WAYPOINT_VALUE = 100;
    private static int LAP_VALUE = 10000;
    private int cpt_waypoint = 0;

	// Use this for initialization
	void Start () {
        currentWaypoint = 0;
        currentLap = 0;
        cpt_waypoint = 0;

	}

    public void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.tag;
        currentWaypoint = System.Convert.ToInt32(otherTag);
        if(currentWaypoint == 1 && cpt_waypoint == nbWaypoint)
        {
            currentLap++;
            cpt_waypoint = 0;
        }
        if(cpt_waypoint == currentWaypoint - 1)
        {
            lastWaypoint = other.transform;
            cpt_waypoint++;
        }
    }

    public float GetDistance()
    {
        return (transform.position - lastWaypoint.position).magnitude + currentWaypoint * WAYPOINT_VALUE + currentLap * LAP_VALUE;
    }

    public int getCarPosition(Cars[] carCollection)
    {
        float distance = GetDistance();
        int position = 1;
        foreach (Cars car in carCollection)
        {
            float distanceCar = car.GetDistance();
            if(distanceCar > distance)
            {
                position++;
            }
        }
        return position;
    }

    public int getCarLap()
    {
        int currentLap = 0;
            currentLap = this.currentLap;
        return currentLap;
    }

}

