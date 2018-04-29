using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponHUDBehaviour : MonoBehaviour {


	public enums.hudWeapon selectedWeaponPanel;

	void Start() {
		selectWeapon (enums.hudWeapon.LASER_CANNON_PANEL);
		selectWeapon (enums.hudWeapon.BULLET_CANNON_PANEL);
		selectWeapon (enums.hudWeapon.SECONDARY_WEAPON_PANEL);
	}

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			selectWeapon (enums.hudWeapon.LASER_CANNON_PANEL);
			//PlayerWeapons.Instance.PreviousSecondary ();
			//gameObject.GetComponent<Text>().text = PlayerWeapons.Instance.selectedSecondary.ToString();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			selectWeapon (enums.hudWeapon.BULLET_CANNON_PANEL);
			//PlayerWeapons.Instance.NextSecondary ();
			//gameObject.GetComponent<Text>().text = PlayerWeapons.Instance.selectedSecondary.ToString();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			selectWeapon (enums.hudWeapon.SECONDARY_WEAPON_PANEL);
			//PlayerWeapons.Instance.NextSecondary ();
		}
	}

	public void selectWeapon(enums.hudWeapon weapon){
		transform.GetChild ((int)weapon).GetComponent<Image> ().CrossFadeAlpha (255f, 1f, true);
		transform.GetChild ((int)weapon).GetComponent<Image> ().CrossFadeAlpha (0f, 1f, true);
		enums.hudWeapon selectedWeaponPanel = weapon;
	}

	public void nextWeapon(){
		switch(selectedWeaponPanel){
		case enums.hudWeapon.LASER_CANNON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.BULLET_CANNON_PANEL;
			break;
		case enums.hudWeapon.BULLET_CANNON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.SECONDARY_WEAPON_PANEL;
			break;
		case enums.hudWeapon.SECONDARY_WEAPON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.LASER_CANNON_PANEL;
			break;
		}
		Debug.Log (selectedWeaponPanel);
		selectWeapon (selectedWeaponPanel);
	}

	public void previousWeapon(){
		switch(selectedWeaponPanel){
		case enums.hudWeapon.LASER_CANNON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.SECONDARY_WEAPON_PANEL;
			break;
		case enums.hudWeapon.BULLET_CANNON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.LASER_CANNON_PANEL;
			break;
		case enums.hudWeapon.SECONDARY_WEAPON_PANEL:
			selectedWeaponPanel = enums.hudWeapon.BULLET_CANNON_PANEL;
			break;
		}
		Debug.Log (selectedWeaponPanel);
		selectWeapon (selectedWeaponPanel);
	}
}
