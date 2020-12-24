using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelComponent : MonoBehaviour, IPoolable
{
    public ObjectsPoolComponent AssociatedPool { get; set; }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("MEMES");
        StartCoroutine(DisableBarrel());
        
    }

    void OnTriggerEnter(Collider collider)
    {
        
        StartCoroutine(DisableBarrel());

    }
    IEnumerator DisableBarrel()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        AssociatedPool.PutObject(gameObject);
    }
}
