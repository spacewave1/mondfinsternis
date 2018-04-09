using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class WaveSpawner : MonoBehaviour
{
    private int _numberOfWaves;
    public int numberOfWaves
    {
        get { return _numberOfWaves; }
    }

    private Wave[] _waves;
    public Wave[] waves
    {
        get { return _waves; }
    }

    private int _spawnRadius;
    public int spawnRadius
    {
        get { return spawnRadius; }
    }

    private int _spawnHeight;
    public int spawnHeight
    {
        get { return spawnHeight; }
    }

    private int _spawnHeightOffset;
    public int spawnHeightOffset
    {
        get { return spawnHeightOffset; }
    }

    private float _spawnWait;
    public float spawnWait
    {
        get { return spawnWait; }
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

	public void setGuiManager(GuiManager guiManager){
		this.guiManager = guiManager;
	}

    void Awake (){
		if (Instance == null) {
			Instance = this;
		}
    }
    public void initSpawn(Wave wave)
    {
;
    }
    protected IEnumerator Spawn(Wave wave)
    {

        //if (AsteroidController.asteroidCount == 0)
        {
            while (wave.wait > 0)
            {
                yield return new WaitForSeconds(1);
                wave.wait--;
            }
            for (int i = 0; i < wave.amount; i++)
            {
                //Quaternion spawnRotation = Quaternion.Euler(Random.insideUnitSphere);
                int index = Calc.WeightedRandomIndex(wave.hostileFrequencies);
                Instantiate(wave.prefabs[index], wave.GetRandomSpawnPoint(), wave.prefabs[index].transform.rotation);
                wave.remaining--;
                yield return new WaitForSeconds(wave.rate);
            }
            yield return new WaitForSeconds(10);
            //WaveSpawner.Instance.NextWave(new Wave());
            Destroy(this);
        }
    }
    public void Start()
    {
        Debug.Log(_numberOfWaves);
		_waves = new Wave[_numberOfWaves];
		//NextWave(new Wave());
		//guiManager.StartCountDown ();
    }
	public Wave initWave(){
		Wave wave = null;

		if (Game.level < 0)
		{
            StartCoroutine(Spawn(wave));
        }
		return wave;
	}

    void OnGUI()
    {
        if (debug)
        {
            _waveDebug = GUI.TextArea(new Rect(10, Screen.height - 210, 200, 200), waveDebug, 200);
        }
    }
	public void NextWave(Wave wave)
    {
   		if (numberOfWaves > Game.level){
			Game.level++;
			//SpawningSequence(wave);
        	wave.Setup();
        	_waveDebug = wave.GetDebugText();
      }
    }
}
