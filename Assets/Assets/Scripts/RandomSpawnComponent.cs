using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnComponent : MonoBehaviour
{
    public GameObject spawnPoint;
    void Start()
    {
        ObjectsPoolComponent pool = this.GetComponent<ObjectsPoolComponent>();
        for (int i = 0; i < pool.poolSize; i++)
        {

            pool.GetObject().transform.position = spawnPoint.transform.position;
        }
    }
}
