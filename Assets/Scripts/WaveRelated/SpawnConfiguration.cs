using System;
using UnityEngine;

[RequireComponent(typeof(WaveSpawner))]
public class SpawnConfiguration : MonoBehaviour
{
	public int numberOfWaves;
	public int spawnRadius;
	public int spawnHeight;
	public int spawnHeightOffset;
	public float spawnWait;
	public GameObject[] prefabs;
    public Wave[] wavesTypes;
	public bool debug;

	private GuiManager guiManager;

	public void Start()
	{
        GetComponent<WaveSpawner>().Configure(this);
		GetComponent<WaveSpawner> ().SetWaveSequence (this);
	}
}

