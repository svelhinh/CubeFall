using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
	private void OnMouseDown()
	{
		GameManager gm = GameManager.Instance;
		CubeSpawner cs = gm.lm.cubeSpawner;

		int givenScore = Mathf.CeilToInt(transform.position.z - cs.transform.position.z + cs.transform.localScale.z / 2.0f / 5.0f) + 1;

		gm.AddScore(givenScore);

		gameObject.SetActive(false);
	}
}
