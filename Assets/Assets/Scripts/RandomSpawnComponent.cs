using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnComponent : MonoBehaviour
{
    public GameObject spawnPoint;
    ObjectsPoolComponent pool;
    void Start()
    {
        pool = this.GetComponent<ObjectsPoolComponent>();
       
        for (int i = 0; i < pool.poolSize; i++)
        {
           pool.GetObject().transform.localPosition = RandomPosition(spawnPoint);
        }
    }
    void Update()
    {
        for (int i = 0; i < pool.poolSize; i++)
        {
            //if()
        }
    }
    private Vector3 RandomPosition(GameObject spawnPoint)
    {
        RectTransform dimention = spawnPoint.transform.GetComponent<RectTransform>();
        Vector3[] array = new Vector3[4];
        dimention.GetLocalCorners(array);
        return new Vector3(Random.Range(0, array[2].x * 2), spawnPoint.transform.position.y, Random.Range(0, array[2].y * 2));
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1);
        pool.GetObject().transform.localPosition = RandomPosition(spawnPoint);
    }
}