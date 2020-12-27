using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnnemieComponent : MonoBehaviour
{

    public GameObject spawnPoint;
    ObjectsPoolComponent pool;
    private float score;
    void Start()
    {
        pool = this.GetComponent<ObjectsPoolComponent>();   
    }
    void Update()
    {
        score += Time.deltaTime;

        if (Mathf.Round(score) > 5)
        {
            GameObject ennemie = pool.GetObject();
            ennemie.transform.localPosition = RandomPosition(spawnPoint);
            ennemie.SetActive(true);
            score = 0;
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
