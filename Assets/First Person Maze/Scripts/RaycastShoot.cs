using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserline;
    private float nextFire;
    private AudioSource gunAudio;

     void Start()
    {
        laserline = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
        gunAudio = GetComponent<AudioSource>();
    }

    private IEnumerator ShotEfect()
    {
        laserline.enabled = true;
        yield return shotDuration;
        laserline.enabled = false;
    }

    void Update()
    {
        

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEfect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            laserline.SetPosition(0, gunEnd.position);

            if(Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserline.SetPosition(1, hit.point);
                Health health = hit.collider.GetComponent<Health>();

                if( health != null)
                {
                    health.TakeDamage(gunDamage);
                }

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
            else
            {
                laserline.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }
        }
    }
}
