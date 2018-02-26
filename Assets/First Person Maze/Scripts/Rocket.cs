using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    public float speed = 1;
    public int gunDamage;
    public GameObject explosionPrefab;

    private void FixedUpdate()
    {
    }
    private void OnCollisionEnter(Collision c)
    {
        Shootable health = c.collider.GetComponent<Shootable>();

        if (health != null)
        {
            health.Damage(gunDamage);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
