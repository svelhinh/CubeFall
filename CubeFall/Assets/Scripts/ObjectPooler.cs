using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
	[System.Serializable]
	public class Pool
	{
		public string tag;
		public GameObject prefab;
		public int size;
	}

	public List<Pool> pools;
	public Dictionary<string, Queue<GameObject>> poolDictionary;

	public static ObjectPooler Instance;

	private void Awake()
	{
		Instance = this;
		poolDictionary = new Dictionary<string, Queue<GameObject>>();
	}

	public void CreatePools()
	{
		poolDictionary.Clear();
		foreach (var pool in pools)
		{
			var objectPool = new Queue<GameObject>();

			for (var i = 0; i < pool.size; i++)
			{
				var obj = Instantiate(pool.prefab);
				obj.SetActive(false);
				objectPool.Enqueue(obj);
			}
			poolDictionary.Add(pool.tag, objectPool);
		}
	}

	public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
	{
		if (!poolDictionary.TryGetValue(tag, out _))
		{
			Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
			return null;
		}

		var objectToSpawn = poolDictionary[tag].Dequeue();

		objectToSpawn.SetActive(true);
		Rigidbody rb = objectToSpawn.GetComponent<Rigidbody>();
		if (rb)
		{
			objectToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
			objectToSpawn.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		objectToSpawn.transform.position = position;
		objectToSpawn.transform.rotation = rotation;

		poolDictionary[tag].Enqueue(objectToSpawn);

		return objectToSpawn;
	}
}
