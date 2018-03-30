using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	private GameObject[] panels;
	public AudioClip[] testSounds;
	public AudioSource audio;

	public enum Panel{
		Main, Play, Options, Highscore
	}

	public enum VolumeType{
		Music, Sound
	}
		
	public void Start() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("MenuPanel");
		panels = new GameObject[objects.Length];

		// Assign the Panels to the panels Variable
		foreach(GameObject panel in objects){
			if (panel.name.Equals ("main_panel"))
				panels [(int)Panel.Main] = panel;
			else if (panel.name.Equals ("play_panel"))
				panels [(int)Panel.Play] = panel;
			else if (panel.name.Equals ("options_panel"))
				panels [(int)Panel.Options] = panel;
			else if (panel.name.Equals ("highscore_panel"))
				panels [(int)Panel.Highscore] = panel;
			Debug.Log (panel);
		}

		panels [(int)Panel.Play].SetActive (false);
		panels [(int)Panel.Options].SetActive (false);
		panels [(int)Panel.Highscore].SetActive (false);
	}
		
	public void StartSimulation() {
		SceneManager.LoadScene("simulation");
	} 

	public void ReturnToMenu() {
		SceneManager.LoadScene ("menu");
	}

	public void showPanel(int panel) {
		switch ((Panel)panel) {
		case(Panel.Play):
			panels [(int)Panel.Play].SetActive (true);
				panels [(int)Panel.Options].SetActive (false);
				panels [(int)Panel.Highscore].SetActive (false);
			break;

		case Panel.Options:
				panels [(int)Panel.Play].SetActive (false);
				panels [(int)Panel.Options].SetActive (true);
				panels [(int)Panel.Highscore].SetActive (false);
			break;

		case Panel.Highscore:
				panels [(int)Panel.Play].SetActive (false);
				panels [(int)Panel.Options].SetActive (false);
				panels [(int)Panel.Highscore].SetActive (true);
			break;
		}
	}

	public void startGame(){
			SceneManager.LoadScene("main");
	}

	public void quit() {
		Debug.Log ("Quit Game");
		Application.Quit ();
	}

	public void changeLoudness(int type){
		switch ((VolumeType)type) {
		case(VolumeType.Music):
			Constants.MUSIC_LOUDNESS = panels [(int)Panel.Options].GetComponentsInChildren<Slider> () [(int)VolumeType.Music].value;
			Debug.Log ("Change Music: " + panels [(int)Panel.Options].GetComponentsInChildren<Slider> () [(int)VolumeType.Music].value);
			break;

		case(VolumeType.Sound):
			Constants.SOUND_LOUDNESS = panels [(int)Panel.Options].GetComponentsInChildren<Slider> () [(int)VolumeType.Sound].value;
			audio.volume += Constants.SOUND_LOUDNESS;
			audio.Play ();
			Debug.Log ("Change Sound: " + panels [(int)Panel.Options].GetComponentsInChildren<Slider> () [(int)VolumeType.Sound].value);
			break;
		}
	}
}
