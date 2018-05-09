using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    public int damage;

    protected override void SingleShot()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag.Equals("hostile"))
        {
            collider.GetComponentInParent<WolfBehaviour>().TakeDamage(damage);
            GetComponent<AudioSource>().Play();
        }
            
    }
}
