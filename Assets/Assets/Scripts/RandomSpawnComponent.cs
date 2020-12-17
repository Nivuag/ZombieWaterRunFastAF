using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnComponent : MonoBehaviour
{
    public GameObject spawnPoint;
    void Start()
    {
        ObjectsPoolComponent pool = this.GetComponent<ObjectsPoolComponent>();
        RectTransform dimention = spawnPoint.transform.GetComponent<RectTransform>();
        Vector3[] array = new Vector3[4];
        dimention.GetLocalCorners(array);
        Debug.Log("1" + array[0]);
        Debug.Log("2" + array[1]);
        Debug.Log("3" + array[2]);
        Debug.Log("4" + array[3]);
        for (int i = 0; i < pool.poolSize; i++)
        {
           pool.GetObject().transform.localPosition = new Vector3(Random.Range(0,array[2].x*2), spawnPoint.transform.position.y, Random.Range(0,array[2].y*2));
        }
    }
}