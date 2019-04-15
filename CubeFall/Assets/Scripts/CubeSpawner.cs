using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
	public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);

	private void OnDrawGizmos()
	{
		Gizmos.color = GizmosColor;
		Gizmos.DrawCube(transform.position, transform.localScale);
	}

	public IEnumerator SpawnCubes()
	{
		ObjectPooler op = ObjectPooler.Instance;
		LevelManager lm = GameManager.Instance.lm;

		while (lm.nbCubesToSpawn > 0)
		{
			Vector3 origin = transform.position;
			Vector3 range = transform.localScale / 2.0f + new Vector3(0f, 0f, -1f);
			Vector3 randomPosition = new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y), Random.Range(-range.z, range.z));

			GameObject cube = op.SpawnFromPool("cube", origin + randomPosition, transform.rotation);

			Vector3 randomRotation = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
			cube.GetComponent<Rigidbody>().AddTorque(randomRotation, ForceMode.Impulse);

			lm.nbCubesToSpawn--;

			yield return new WaitForSeconds(lm.cubeSpawnWaitingTime);
		}

		yield return new WaitForSeconds(1f);

		GameManager.Instance.LoadScene("Score");
	}
}
