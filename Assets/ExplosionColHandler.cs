using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionColHandler : MonoBehaviour {

    public int damageAmount;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Here is a Collission");
        Debug.Log(col.name);
        if (col.tag.Equals("hostile"))
        {
            col.GetComponentInParent<HitPoints>().ReduceHitPoints(damageAmount);
        }
    }

    void Start()
    {
        Debug.Log("Start of explosion");
    }

}
