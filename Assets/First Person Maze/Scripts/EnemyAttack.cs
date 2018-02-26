using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public Transform player;
    
    public float range = 30.0f;
    //public float bulletSpeed = 20.0f;
    
    public int gunDamage = 1;
    public float fireRate = .25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;
    private bool onRange = false;
    private Camera fpsCam;

    //public GameObject bullet;
    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
    private LineRenderer laserline;
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        float timer = Random.Range(1.0f, 2.0f);
        laserline = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
        InvokeRepeating("Shoot", 4, timer);
    }

    private IEnumerator ShotEfect()
    {
        laserline.enabled = true;
        yield return shotDuration;
        laserline.enabled = false;
    }
    void Shoot()
    {
   
        if (onRange && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEfect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
            RaycastHit hit;
            laserline.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserline.SetPosition(1, hit.point);
                PlayerHealth health = hit.collider.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

                if (hit.rigidbody != null)
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

    // Update is called once per frame
    void Update()
    {
        onRange = Vector3.Distance(transform.position, player.position) < range;

        if (onRange)
        {
            transform.LookAt(player);
        }

    }
}
