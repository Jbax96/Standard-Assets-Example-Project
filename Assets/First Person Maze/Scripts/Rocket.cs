using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float speed = 1;

    public GameObject explosionPrefab;

    private void FixedUpdate()
    {
        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        // Check bullet location relative to explosion
        //rigidbody.AddForce(transform.position * speed, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision c)
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
