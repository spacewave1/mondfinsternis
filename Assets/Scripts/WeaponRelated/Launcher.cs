using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is used for any kind of weapon, that launches a projectile of any type
// it holds the projectile's prefab and the barrels (as muzzles) used to fire
// if more than one muzzle is used, the Launcher-class cycles through the muzzles
public class Launcher : Weapon
{

    public GameObject projectilePrefab;
    public int initialVelocity = 0;

    public override void Start(){
        base.Start();
    }
    /*protected override void FireWeapon()
    {
        //Instatiate a new projectile and launch it where the cannon points at

		    		GameObject projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = muzzles[muzzleIndex].transform.position;
            projectile.transform.forward = muzzles[muzzleIndex].transform.forward;

            projectile.GetComponent<Rigidbody>().velocity = muzzles[muzzleIndex].transform.forward * initialVelocity;
						//Cycle through available muzzles
						if (muzzleIndex >= (muzzles.Length-1)){
							muzzleIndex = 0;
						} else {
							muzzleIndex++;
						}


    }*/
    protected override void SingleShot(){
        //Instatiate a new projectile and launch it where the cannon points at
        GameObject projectile = Instantiate(projectilePrefab) as GameObject;
		projectile.transform.position = muzzle.transform.position;
		projectile.transform.forward = muzzle.transform.forward;
		//projectile.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * initialVelocity;
		if(GetComponent<AudioSource> ()!=null) GetComponent<AudioSource>().Play ();
        if(GetComponent<Animator>() != null) GetComponent<Animator>().SetTrigger("fire");
          //Cycle through available muzzles
    }
}
