using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour {

	public GameObject canvasObj;
	public GameObject androidCanvasObj;
	public GameObject viveCanvasObj;
	public WaveSpawner waveController;
	public Text countdownText;
	private Wave wave;
	public HitPoints healthObject;

	public PointHUD points;

	// Use this for initialization
	public void StartCountDown () {

		if (androidCanvasObj.activeInHierarchy)
			canvasObj = androidCanvasObj;
		else if (viveCanvasObj.activeInHierarchy)
			canvasObj = viveCanvasObj;


		countdownText = canvasObj.transform.GetChild(0).gameObject.GetComponent<Text> ();
		//wave = waveController.getWave ();
		points = canvasObj.transform.GetChild (2).gameObject.GetComponentInChildren<PointHUD> ();
		//StartCoroutine (CountDown (countdownDuration));
	}

	public void findAndRegulateCanvas(){
		canvasObj = GameObject.FindGameObjectWithTag ("Canvas");
		if (RuntimePlatform.Android == Application.platform && androidCanvasObj != null)
			viveCanvasObj.SetActive (false);
		else if (RuntimePlatform.Android != Application.platform)
			androidCanvasObj.SetActive (false);

	}

	void Update(){

		if (wave != null ) {
			if (GameControllerScript.isGameRunning) {
				if (wave.getWait () > 6 || wave.getWait () == 5 || wave.getWait() <= 0)
					countdownText.text = "";
				else if (wave.getWait () == 6 || wave.getWait () == 4)
					countdownText.text = "Get Ready";
				else if (wave.getWait () == 1)
					countdownText.text = "GO";
				else
					countdownText.text = (wave.getWait () - 1).ToString ();
			}
			if (healthObject.hpHasChanged) {
				UpdateHealth (healthObject.hp);
				healthObject.hpHasChanged = false;
			}
		}		
	}

	public void UpdateHealth(float newValue){
		if (points == null) {
			points = canvasObj.transform.GetChild (2).gameObject.GetComponentInChildren<PointHUD> ();
			points.gameObject.GetComponentInChildren<Slider> ().maxValue = healthObject.maximumHitPoints;
		} 
		if (newValue <= 0) {
			showGameOver ();
		}
			
		points.updatePoints(enums.hudPoints.HEALTH_PANEL, newValue);
	}

	public void UpdateScore(float newValue){
		Debug.Log (newValue);
		Debug.Log (points);
		points.updatePoints (enums.hudPoints.SCORE_PANEL, newValue);
	}

	private void showGameOver(){
		Debug.Log ("Show game Over");
		countdownText.text = "Game Over";
	}
}
