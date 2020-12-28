using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnnemieComponent : MonoBehaviour
{

    public GameObject spawnPoint;
    ObjectsPoolComponent pool;
    private float score;
    private int compteurSpawn = 0;
    public int timeToWait = 5;
    void Start()
    {
        pool = this.GetComponent<ObjectsPoolComponent>();   
    }
    void Update()
    {
        score += Time.deltaTime;

        if (Mathf.Round(score) > timeToWait && compteurSpawn < pool.poolSize)
        {
            GameObject ennemie = pool.GetObject();
            ennemie.transform.localPosition = RandomPosition(spawnPoint);
            ennemie.SetActive(true);
            ennemie.GetComponent<EnnemieController>().patrolArea = spawnPoint;
            score = 0;
            compteurSpawn++;
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
