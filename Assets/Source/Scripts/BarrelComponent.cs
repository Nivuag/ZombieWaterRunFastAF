using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelComponent : MonoBehaviour, IPoolable
{
    public ObjectsPoolComponent AssociatedPool { get; set; }

    public void DisableBarrelCoroutine()
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
