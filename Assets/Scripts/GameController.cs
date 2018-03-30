using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	void Awake (){
		if (instance == null) {
			instance = this;
			Game.level = 0;
		}
	}

	public void Pause() {
		Time.timeScale = 0;
	}

	public void unPause() {
		Time.timeScale = 1;
	}

	public void runWave(){

	}

	public void initNextLevel(Game game) {

	}
}
