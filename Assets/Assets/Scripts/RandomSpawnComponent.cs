using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnComponent : MonoBehaviour
{
    public GameObject SpawnPoint;
    void Awake()
    {
        ObjectsPoolComponent pool = this.GetComponent<ObjectsPoolComponent>();
        for (int i = 0; i < pool.poolSize; i++)
        {
            GameObject ok ;
        }
    }
}
