using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PointHUD : MonoBehaviour {

    public static int crystals;
    public static Dictionary<string, int> value = new Dictionary<string, int>();
	Text text;

	private GuiManager uiManager;
    // Use this for initialization
    void Awake()
    {
    value.Add("low", 100);
    value.Add("high", 500);
    text = GetComponent<Text>();
		crystals = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			updatePoints (enums.hudPoints.SCORE_PANEL, 300);
			//TurretWeapons.Instance.PreviousSecondary ();
			//gameObject.GetComponent<Text>().text = TurretWeapons.Instance.selectedSecondary.ToString();
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			updatePoints (enums.hudPoints.CRYSTALS_PANEL, 200);
			//TurretWeapons.Instance.NextSecondary ();
			//gameObject.GetComponent<Text>().text = TurretWeapons.Instance.selectedSecondary.ToString();
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			updatePoints (enums.hudPoints.HEALTH_PANEL, 0.1f);
			//TurretWeapons.Instance.NextSecondary ();
		}

		//text.text = ""+crystals;
	}

	public void updatePoints(enums.hudPoints point, float newPointValue){
		switch (point) {
		case enums.hudPoints.HEALTH_PANEL:
			// get the Point HUD
			transform.GetChild ((int)point).GetComponent<Slider> ().value = newPointValue;
			break;
		case enums.hudPoints.SCORE_PANEL:
			transform.GetChild ((int)point).GetComponent<Text> ().text = "" + ((int) newPointValue).ToString();
			break;
		case enums.hudPoints.CRYSTALS_PANEL:
			break;
		}
	}
		
}
