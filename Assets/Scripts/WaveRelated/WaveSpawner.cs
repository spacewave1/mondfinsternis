using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class WaveSpawner : MonoBehaviour
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

	public void setGuiManager(GuiManager guiManager){
		this.guiManager = guiManager;
	}

    void Awake (){
		if (Instance == null) {
			Instance = this;
		}
    }
    public void Start()
    {
        GameObject[] prefabs = { smallAsteroidPrefab, largeAsteroidPrefab, fastAsteroidPrefab };
        this.prefabs = prefabs;
		waves = new Wave[numberOfWaves];
		//NextWave(new Wave());
		guiManager.StartCountDown ();
    }
	public Wave initWave(){
		Wave wave = null;

		if (Game.level < 0)
		{
			wave = new GameObject ().AddComponent<StandardWave>();
		}
		else
		{
			switch (Game.level % 3)
			{
			case 1:
				wave = new GameObject().AddComponent<StandardWave>();
				break;
			case 0:
				wave = new GameObject().AddComponent<HeavyWave>();
				break;
			case 2:
				wave = new GameObject().AddComponent<StormWave>();
				break;
			default:
				wave = new GameObject().AddComponent<StandardWave>();
				break;
			}
		}
		return wave;
	}

    void OnGUI()
    {
        if (debug)
        {
            waveDebug = GUI.TextArea(new Rect(10, Screen.height - 210, 200, 200), waveDebug, 200);
        }
    }
	public void NextWave(Wave wave)
    {
   		if (numberOfWaves > Game.level){
			Game.level++;
			SpawningSequence(wave);
        	wave.Setup();
        	wave.enabled = true;
        	waveDebug = wave.GetDebugText();
      }
    }
	public void SpawningSequence(Wave wave)
    {
		if (Game.level < 0)
        {
            wave = gameObject.AddComponent<StandardWave>();
        }
        else
        {
			switch (Game.level % 3)
            {
                case 1:
                    wave = gameObject.AddComponent<StandardWave>();
                    break;
                case 0:
                    wave = gameObject.AddComponent<HeavyWave>();
                    break;
                case 2:
                    wave = gameObject.AddComponent<StormWave>();
                    break;
                default:
                    wave = gameObject.AddComponent<StandardWave>();
                    break;
            }
        }
    }
}
