using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public Transform player;
    public float range = 30.0f;
    public float bulletSpeed = 20.0f;

    private bool onRange = false;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        float timer = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, timer);
	}

    void Shoot()
    {
        if (onRange)
        {
            GameObject newBullet = Instantiate(bullet, transform.position + transform.forward, transform.rotation);

        }
    }
	
	// Update is called once per frame
	void Update () {
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
        {
            transform.LookAt(player);
        }
		
	}
}
