using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    ObjectPool pool;

    void Start()
    {
        GameObject[] gameControllers = GameObject.FindGameObjectsWithTag("GameController");

        if (gameControllers.Length > 0 && gameControllers[0].GetComponent<ObjectPool>() != null)
        {
            pool = gameControllers[0].GetComponent<ObjectPool>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (pool == null)
        {
            Destroy(other.gameObject);
            return;
        }

        pool.DestroyInstancedObject(other.gameObject);
    }
}
