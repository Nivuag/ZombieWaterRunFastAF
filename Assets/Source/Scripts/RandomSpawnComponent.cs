using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnComponent : MonoBehaviour
{
    public GameObject spawnPoint;
    ObjectsPoolComponent pool;
    private List<GameObject> listBarel = new List<GameObject>();
    private float elapsedTime = 0;
    void Start()
    {
        pool = this.GetComponent<ObjectsPoolComponent>();
       
        for (int i = 0; i < pool.poolSize; i++)
        {
            GameObject barel = pool.GetObject();
            barel.transform.localPosition = RandomPosition(spawnPoint);
            listBarel.Add(barel);
        }
    }
    void Update()
    {

        elapsedTime += Time.deltaTime;
        if(elapsedTime > 3)
        {
            foreach (var item in listBarel)
            {
                if(!item.active)
                {
                    item.transform.localPosition = RandomPosition(spawnPoint);
                    item.SetActive(true);
                }
            }
            elapsedTime = 0;
        }
    }
    private Vector3 RandomPosition(GameObject spawnPoint)
    {
        RectTransform dimention = spawnPoint.transform.GetComponent<RectTransform>();
        Vector3[] array = new Vector3[4];
        dimention.GetLocalCorners(array);
        return new Vector3(Random.Range(0, array[2].x * 2), spawnPoint.transform.position.y, Random.Range(0, array[2].y * 2));
    }
}