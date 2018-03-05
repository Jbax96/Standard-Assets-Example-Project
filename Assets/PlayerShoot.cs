using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1")){
            Fire();
        }
	}

    void Fire()
    {
        //Create Bullet
        GameObject bullet = Instantiate(BulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        //Add velocity to bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
    
        //Destroy bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
