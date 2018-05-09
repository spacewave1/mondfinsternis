using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FireWeapon : MonoBehaviour {

    private Weapon weapon;

		public void Start()
    {
        if (gameObject.GetComponent<Launcher>() != null)
        {
            weapon = gameObject.GetComponent<Launcher>();
		} else if (gameObject.GetComponent<RayGun>() != null){
        weapon = gameObject.GetComponent<RayGun>();
      } else if(gameObject.GetComponent<Knife>() != null)
        {
            weapon = gameObject.GetComponent<Knife>();
        }

        else {
            Debug.Log("No weapon component found!");
				return;
        }
			weapon.Start();
		}
    public void Fire(){
			weapon.Fire();
    }
	public void SetToPrimary(){
        Debug.Log(name);
		weapon.SetToPrimary();
	}
    //This Start-function checks once, which type of weapon is used and creates a reference to the Fire()-function

}
