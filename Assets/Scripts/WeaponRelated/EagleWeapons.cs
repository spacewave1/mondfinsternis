using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleWeapons : MonoBehaviour {

    public GameObject rightMuzzle;
    public GameObject[] primaryWeapons;
    public int selectedPrimary = 0;
	public static EagleWeapons Instance { get; private set; }
    private LineRenderer line;
	public SpriteRenderer laserIndicator;

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
  }
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey(KeyCode.V)){
          FirePrimary();
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
		public void FirePrimary(){
		Debug.Log ("Fire Primary");
			primaryWeapons[selectedPrimary].GetComponent<FireWeapon>().Fire();
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
         	line.enabled = false;
    }
	public void EnableRay(Material material){
		line.material = material;
		laserIndicator.enabled = true;
		line.enabled = true;
	}
	public void DisableRay(){
		laserIndicator.enabled = false;
		line.enabled = false;
	}
}
