using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject muzzle;
    public int velocity = 100;
    public int damage = 100;
    protected Vector3 aim;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            shoot();
            
        }
    }
    void shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
        projectile.transform.position = muzzle.transform.position;
        projectile.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * velocity;
    }
}
