using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public List<Pool> pools;
    Dictionary<string, Queue<GameObject>> poolDictionary;

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 positon, float xOffset = 0f, float yOffset=0, float zOffset = 0f)
    {
        if (!poolDictionary.ContainsKey(tag)) return null;

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        if (objectToSpawn.active)
        {
            poolDictionary[tag].Enqueue(objectToSpawn);
            return null;
        }

        objectToSpawn.transform.position = new Vector3(positon.x+ xOffset, positon.y+ yOffset, positon.z+ zOffset);
        objectToSpawn.SetActive(true);
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
