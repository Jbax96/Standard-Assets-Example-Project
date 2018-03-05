using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        GameObject hit = collider.gameObject;
        Health health = hit.GetComponent<Health>();
        if (collider.gameObject.tag == "Enemy")
        {
            if (health != null)
            {
                health.TakeDamage(10);
                Destroy(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }
}
