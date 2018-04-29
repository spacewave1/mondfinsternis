using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{

    public int damage;

    protected override void SingleShot()
    {
        
    }

    void OnCollision(Collider collider)
    {
        if(collider.tag.Equals("hostile"))
            collider.GetComponentInParent<WolfBehaviour>().TakeDamage(damage);
    }
}
