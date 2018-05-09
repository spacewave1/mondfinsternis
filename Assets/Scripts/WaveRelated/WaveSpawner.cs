using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

public class WaveSpawner : MonoBehaviour
{
    private int _numberOfWaves;
    public int numberOfWaves
    {
        get { return _numberOfWaves; }
    }
		
    private List<Wave> _waves;
    public List<Wave> waves
    {
        get { return _waves; }
    }

    private int _spawnRadius;
    public int spawnRadius
    {
        get { return _spawnRadius; }
    }

    private int _spawnHeight;
    public int spawnHeight
    {
        get { return _spawnHeight; }
    }

    private int _spawnHeightOffset;
    public int spawnHeightOffset
    {
        get { return _spawnHeightOffset; }
    }

    private float _spawnWait;
    public float spawnWait
    {
        get { return _spawnWait; }
    }

    private GameObject[] _prefabs = null;
    public GameObject[] prefabs
    {
        get { return _prefabs; }
    }

    private string _waveDebug = "";
    public string waveDebug
    {
        get { return _waveDebug; }
    }

    private bool _debug = false;
    public bool debug
    {
        get { return _debug; }
    }

    private bool _spawningWave;
    public bool spawningWave
    {
        get { return _spawningWave; }
    }

	public static WaveSpawner Instance = null;

	private GuiManager guiManager;

    public void Configure(SpawnConfiguration spawnConfiguration)
    {
        this._numberOfWaves = spawnConfiguration.numberOfWaves;
        this._spawnRadius = spawnConfiguration.spawnRadius;
        this._spawnHeight = spawnConfiguration.spawnHeight;
        this._spawnHeightOffset = spawnConfiguration.spawnHeightOffset;
        this._spawnWait = spawnConfiguration.spawnWait;
        this._prefabs = spawnConfiguration.prefabs;
    }
		
	public void SetWaveSequence(SpawnConfiguration spawnConfiguration){
		Wave wave;
		for (int i = 0; i < numberOfWaves; i++) {
			wave = spawnConfiguration.waveTypes [spawnConfiguration.spawnSequence[i]];
			_waves.Add (wave);
		}
	}


	public void setGuiManager(GuiManager guiManager){
		this.guiManager = guiManager;
	}

    void Awake (){
		if (Instance == null) {
			Instance = this;
		}
        _waves = new List<Wave>();
    }

    protected IEnumerator Spawn(Wave wave)
    {

        //if (AsteroidController.asteroidCount == 0)
        
            while (wave.wait > 0)
            {
                yield return new WaitForSeconds(1);
                wave.wait--;
            }
            for (int i = 0; i < wave.amount; i++)
            {
                //Quaternion spawnRotation = Quaternion.Euler(Random.insideUnitSphere);
                int index = Calc.WeightedRandomIndex(wave.hostileFrequencies);
            if(i == 0)
            {
                Instantiate(wave.prefabs[0], wave.GetRandomSpawnPoint(), wave.prefabs[index].transform.rotation).GetComponent<Animator>().SetTrigger("howl");
            } else
            {
                Instantiate(wave.prefabs[index], wave.GetRandomSpawnPoint(), wave.prefabs[index].transform.rotation);
            }
                wave.remaining--;
                yield return new WaitForSeconds(wave.rate);
            }
            yield return new WaitForSeconds(10);
            NextWave();
        yield return null;
            
    }
    public void Start()
    {
        Debug.Log(_numberOfWaves);

		//_waves = new List<Wave>();
        NextWave();
		//guiManager.StartCountDown ();
    }
	public Wave initSpawn(Wave wave){
        StartCoroutine(Spawn(wave));    
		//NextWave();
		//guiManager.StartCountDown ();
		return wave;
	}

    void OnGUI()
    {
        if (debug)
        {
            _waveDebug = GUI.TextArea(new Rect(10, Screen.height - 210, 200, 200), waveDebug, 200);
        }
    }
	public void NextWave()
    {
		_waves [0].Setup();
    	_waveDebug = _waves[0].GetDebugText();
		initSpawn (_waves[0]);
		_waves.RemoveAt (0);
		Game.level++;
      }
}