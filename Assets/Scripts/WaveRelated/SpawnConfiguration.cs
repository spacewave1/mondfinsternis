﻿using System;
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
    public Wave[] waveTypes;
	public bool debug;
    public int[] spawnSequence;

	private GuiManager guiManager;

	public void Start()
	{
        GetComponent<WaveSpawner>().Configure(this);
		GetComponent<WaveSpawner> ().SetWaveSequence (this);
	}
}

