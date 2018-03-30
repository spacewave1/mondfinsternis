using System;
using UnityEngine;
using UnityEngine;

public class SpawnConfiguration : MonoBehaviour
{
	public int numberOfWaves;
	public GameObject smallAsteroidPrefab;
	public GameObject largeAsteroidPrefab;
	public GameObject fastAsteroidPrefab;
	public int spawnRadius = 30;
	public int spawnHeight = 10;
	public int spawnHeightOffset = -2;
	public float spawnWait = 5;
	private Wave[] waves;
	private GameObject[] prefabs;
	public Wave wave;
	private string waveDebug = "";
	public static bool debug = false;
	private bool spawningWave;

	private GuiManager guiManager;

	public SpawnConfiguration ()
	{
		
	}
}

