using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerWeapons : MonoBehaviour {

    public GameObject leftMuzzle;
    public GameObject rightMuzzle;
    public GameObject[] primaryWeapons;
    public GameObject[] secondaryWeapons;
    public int selectedPrimary = 0;
    public int selectedSecondary = 0;
    public static PlayerWeapons Instance { get; private set; }
    public Hand rightHand;
    public Hand leftHand;
    
    private LineRenderer line; 

  // Use this for initialization
	void Awake () {
        Instance = this;
    }
    void Start()
    {
      if (gameObject.GetComponent<LineRenderer>() != null){
        line = gameObject.GetComponent<LineRenderer>();
    } else {
      Debug.Log("No line renderer found for this ray-gun type weapon!");
    }
    foreach (GameObject weapon in primaryWeapons) {
            weapon.GetComponent<FireWeapon>().Start();
			weapon.GetComponent<FireWeapon>().SetToPrimary();

            //Instantiate(weapon, PlayerWeapons.Instance.gameObject.transform);
        }
        foreach (GameObject weapon in secondaryWeapons) {
			weapon.GetComponent<FireWeapon>().Start();
            //Instantiate(weapon, PlayerWeapons.Instance.gameObject.transform);
        }
  }
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.C)) {
          FireSecondary();
        }
        if(rightHand.controller != null && rightHand.controller.GetHairTrigger())
        if (Input.GetKey(KeyCode.V))
        {
          FirePrimary();
        }
        if(secondaryWeapons[selectedSecondary].GetType() == typeof(Knife))
        {
            FireSecondary();
        }
    }
		public void NextPrimary(){
			if (selectedPrimary == primaryWeapons.Length-1){
				selectedPrimary = 0;
			} else {
				selectedPrimary++;
			}
		}

		public void PreviousPrimary(){
			if (selectedPrimary == 0){
				selectedPrimary = primaryWeapons.Length-1;
			} else {
				selectedPrimary--;
			}
    }
		public void NextSecondary(){
			if (selectedSecondary == secondaryWeapons.Length-1){
				selectedSecondary = 0;
			} else {
				selectedSecondary++;
			}
		}

		public void PreviousSecondary(){
			if (selectedSecondary == 0){
				selectedSecondary = secondaryWeapons.Length-1;
			} else {
				selectedSecondary--;
			}
    }
		public void FirePrimary(){
			primaryWeapons[selectedPrimary].GetComponent<FireWeapon>().Fire();
		}
    public void FireSecondary()
    {
		secondaryWeapons[selectedSecondary].GetComponent<FireWeapon>().Fire();
    }
    public GameObject GetLeftMuzzle(){
      return leftMuzzle;
    }
    public GameObject GetRightMuzzle(){
      return rightMuzzle;
    }
    public void ShootRay (Material material, float duration){
      StartCoroutine(RenderLine(material, duration));
    }
    IEnumerator RenderLine(Material material, float duration)
    {
        line.material = material;
      	line.enabled = true;
      	yield return new WaitForSeconds(duration);
		DisableRay ();
    }
	public void EnableRay(Material material){
		line.material = material;
		line.enabled = true;
	}
	public void DisableRay(){
		if (primaryWeapons.Length != 0)primaryWeapons[selectedPrimary].GetComponent<AudioSource>().Stop();
		if (secondaryWeapons.Length != 0) secondaryWeapons[selectedPrimary].GetComponent<AudioSource>().Stop();
		line.enabled = false;
	}
}
