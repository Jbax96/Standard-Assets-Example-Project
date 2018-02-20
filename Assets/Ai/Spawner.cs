using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemy;
    public float spawnInterval;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {

        InvokeRepeating("Spawn", spawnInterval, spawnInterval);
	}


    void Spawn () {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}

}
