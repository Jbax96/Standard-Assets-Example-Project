using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cars : MonoBehaviour {
    public int currentWaypoint;
    public int currentLap;
    public Transform lastWaypoint;
    public int nbWaypoint;
    public Text position;

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
            return position;
        }
        return position;
    }
}
public class RaceController : MonoBehaviour
{
    public Cars[] carCollection;
    public Cars[] carPosition;

    // Use this for initialization
    public void Start()
    {
        //set up the car objects
        carPosition = new Cars[carPosition.Length];
        InvokeRepeating("Update", 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Cars car in carCollection)
        {
            carPosition[car.getCarPosition(carCollection) - 1] = car;
        }
    }
} 
