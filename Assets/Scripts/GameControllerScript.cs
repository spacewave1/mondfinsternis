using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameControllerScript : NetworkBehaviour {

	public static bool isPaused = true;					// Boolean that holds the information, whether the game is paused or not
	public static byte startCmdCalled = 0;				// Count how often the StartCmd has been called
	public static bool isGameRunning = true;
	private Button pauseBtn;						// The Text of the pause button


	void Start(){
		//Pause only possible from eagle
		//pauseBtn = GameObject.Find ("pause_btn").GetComponent<Button>();
	}

	public static void updateScore(){

	}

	// Toggle Pause
	public void togglePause(){
		if (isPaused == false) {
			RpcPause ();
		} else {
			RpcContinue ();
		}
	}

	// Pause or Continue by setting the time unit length to zero, set the isPaused boolen and adjust the btn text

	[ClientRpc]
	private void RpcPause()
	{
		Time.timeScale = 0.0f;
		Debug.Log ("Paused Game");
		isPaused = true;
		//pauseBtn == paused;
	}

	[ClientRpc]
	private void RpcContinue()
	{
		Time.timeScale = 1;
		Debug.Log ("unPaused Game");
		isPaused = false;
		//pauseBtn = unpause;
    }
}
