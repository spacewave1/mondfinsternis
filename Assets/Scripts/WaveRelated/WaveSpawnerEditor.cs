using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(WaveSpawner))]
public class WaveSpawnerditor : Editor
{
    public int numberOfWaves;
    public GameObject smallAsteroidPrefab;
    public GameObject largeAsteroidPrefab;
    public GameObject fastAsteroidPrefab;
	public Wave[] waves;
    public int spawnRadius = 30;
    public int spawnHeight = 10;
    public int spawnHeightOffset = -2;
    public float spawnWait = 5;
    private GameObject[] prefabs;
    private string waveDebug = "";
    public static bool debug = false;
    private bool spawningWave;
	public static WaveSpawner Instance = null;

	private GuiManager guiManager;

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
	}
}
