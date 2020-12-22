using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPoolComponent : MonoBehaviour
{
    public GameObject objectToPool;
    public int poolSize = 20;

    private ObjectPool<GameObject> objectPool;

    public GameObject GetObject() => objectPool.GetObject();
    public void PutObject(GameObject objectToPut) => objectPool.PutObject(objectToPut);

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>();
        FillPool();
    }

    private void FillPool()
    {
        var namePrefix = objectToPool.name;
        for (int i = 0; i < poolSize; ++i)
        {
            var newObject = Instantiate(objectToPool, transform);
            newObject.GetComponent<IPoolable>().AssociatedPool = this;
            newObject.name = $"{namePrefix} {i}";
            newObject.SetActive(true);
            objectPool.PutObject(newObject);
        }
    }
}
