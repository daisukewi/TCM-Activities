using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
   public GameObject prefabToInstantiate;

    List<GameObject> pooledObjects;
    public int amountToPool = 10;

    int nextInPool = 0;

    public bool UsePool { get { return amountToPool > 0; } }

    void Start()
    {
        if (UsePool)
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for(int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(prefabToInstantiate, gameObject.transform);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

    public void SpawnAtPosition(Vector3 spawnPosition)
    {
        if (!UsePool)
        {
            Instantiate(prefabToInstantiate, spawnPosition, Quaternion.identity, gameObject.transform);
            return;
        }

        if (nextInPool >= pooledObjects.Count)
            nextInPool = 0;

        GameObject objectToSpawn = pooledObjects[nextInPool++];

        objectToSpawn.transform.SetPositionAndRotation(spawnPosition, Quaternion.identity);
        objectToSpawn.SetActive(true);
    }

    public void DestroyInstancedObject(GameObject spawnedObject)
    {
        if (!UsePool)
        {
            Destroy(spawnedObject);
            return;
        }

        nextInPool = pooledObjects.IndexOf(spawnedObject);
        spawnedObject.SetActive(false);
    }
}
