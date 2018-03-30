using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public abstract class Wave : MonoBehaviour
{
    protected int wait;
    protected float rate;
    protected int amount;
    protected int remaining;
    protected int spread;
    protected int direction;
    protected GameObject[] asteroidPrefabs;
    protected int[] hostileFrequencies;
    //spawn bounds
    protected int yMin;
    protected int yMax;
    protected int rMin;
    protected int rMax;
    //GUI
    string waitText;


    /// <summary>
    /// Sets the frequencies of Asteroids.
    /// The order is defined by the asteroidPrefab-Array within AsteroidWaveController.
    /// </summary>
    protected void SetFrequencies(int small, int large, int fast)
    {
        int[] frequencies = { small, large, fast };
        hostileFrequencies = frequencies;
    }
    protected abstract void SetValues();
    protected void SetSpawnBounds()
    {
        rMin = direction - (spread / 2);
        rMax = direction + (spread / 2);
        yMin = 0 + WaveSpawner.Instance.spawnHeightOffset;
        yMax = WaveSpawner.Instance.spawnHeight + WaveSpawner.Instance.spawnHeightOffset;

    }
    public void Setup()
    {
      	//this.asteroidPrefabs = WaveSpawner.Instance.GetPrefabs();
		direction = Random.Range(0,360);
      	SetValues();
      	SetSpawnBounds();
      	remaining = amount;
    }

    public Vector3 GetRandomSpawnPoint()
    {
		int angle = Random.Range(rMin, rMax);
        Vector2 vector = Calc.PolarToCartesian(WaveSpawner.Instance.spawnRadius, angle);
		Debug.Log ("spawn bounds: " + rMin + "(rmin) " + rMax + "(rmax) " + angle + "(angle) " + spread + "(spread)");
        int x = (int)vector.x;
        int z = (int)vector.y;
        int y = Random.Range(yMin, yMax);
        return new Vector3(x, y, z);
    }
    public int GetAmount()
    {
        return amount;
    }
    public float GetRate()
    {
        return rate;
    }
    public int getWait(){
      return wait;
    }

    public GameObject GetRandomAsteroidType()
    {
      GameObject asteroidType = asteroidPrefabs[Calc.WeightedRandomIndex(hostileFrequencies)];
      return asteroidType;
    }
    public string GetDebugText(){
        string debugText = "WaveDebug: ";
        debugText += "\ntime to wave: " + wait;
		debugText += "\nlevel: " + Game.level;
        debugText += "\ndirection: " + direction;
        debugText += "\nspread: " + spread;
        debugText += "\nrate: " + rate;
        debugText += "\nspawned: " + (amount - remaining) + "/" + amount;
        //debugText += "\nasteroids: " + AsteroidController.asteroidCount;
        debugText += "\nbounds: ";
        debugText += "\ny (" + yMin + ", " + yMax +")";
        debugText += "\nr (" + rMin + ", " + rMax +")";
        return debugText;
    }
    protected void Awake(){
      this.enabled = false;
    }
    public void Start(){

      StartCoroutine(Spawn());

    }
    protected IEnumerator Spawn()
    {

        //if (AsteroidController.asteroidCount == 0)
        {
          while (wait > 0){
            yield return new WaitForSeconds(1);
            wait--;
          }
          for (int i = 0; i < amount; i++)
          {
				//Quaternion spawnRotation = Quaternion.Euler(Random.insideUnitSphere);
				int index =	Calc.WeightedRandomIndex (hostileFrequencies);
				Instantiate (asteroidPrefabs [index], GetRandomSpawnPoint (), asteroidPrefabs[index].transform.rotation);
           		remaining--;
            	yield return new WaitForSeconds(rate);
            }
          yield return new WaitForSeconds(10);
			//WaveSpawner.Instance.NextWave(new Wave());
          Destroy(this);
        }
    }
    void OnGUI(){
        if (wait > 0){
           waitText = GUI.TextArea(new Rect((Screen.width/2)-60, 10, 120, 20), "Next Wave in: " + wait + " s" ,200);
        }
    }

}
