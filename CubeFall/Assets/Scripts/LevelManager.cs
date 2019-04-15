using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public float cubeSpawnWaitingTime;
	public int nbCubesToSpawn;

	public CubeSpawner cubeSpawner;

	private ObjectPooler op;

	private void Awake()
	{
		GameManager.Instance.lm = this;
		GameManager.Instance.score = 0;
	}

	private void Start()
	{
		op = ObjectPooler.Instance;
		op.CreatePools();
		StartCoroutine(cubeSpawner.SpawnCubes());
	}
}
