using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[System.Serializable]
public class Wave 
{

    public int wait;
    public float rate;
    public int amount;
    public int spread;
    public int direction;
    public GameObject[] prefabs;
    public int[] hostileFrequencies;
    //spawn bounds
    protected int yMin;
    protected int yMax;
    protected int rMin;
    protected int rMax;
    //GUI
    private string waitText;
    public int remaining;


    /// <summary>
    /// Sets the frequencies of Asteroids.
    /// The order is defined by the asteroidPrefab-Array within AsteroidWaveController.
    /// </summary>
    protected void SetFrequencies(int small, int large, int fast)
    {
        int[] frequencies = { small, large, fast };
        hostileFrequencies = frequencies;
    }
    //protected void SetValues();
    protected void SetSpawnBounds()
    {
        Debug.Log("Hello");
        rMin = direction - (spread / 2);
        rMax = direction + (spread / 2);
        yMin = 0 + WaveSpawner.Instance.spawnHeightOffset;
        yMax = WaveSpawner.Instance.spawnHeight + WaveSpawner.Instance.spawnHeightOffset;

    }
    public void Setup()
    {
      	//this.asteroidPrefabs = WaveSpawner.Instance.GetPrefabs();
		direction = Random.Range(0,360);
      	//SetValues();
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
      GameObject asteroidType = prefabs[Calc.WeightedRandomIndex(hostileFrequencies)];
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
    
    void OnGUI(){
        if (wait > 0){
           waitText = GUI.TextArea(new Rect((Screen.width/2)-60, 10, 120, 20), "Next Wave in: " + wait + " s" ,200);
        }
    }

}
