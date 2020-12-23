using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelComponent : MonoBehaviour, IPoolable
{
    public ObjectsPoolComponent AssociatedPool { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.tag == "Player")
        {
            Debug.Log("Triggered by Enemy");
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
       
            StartCoroutine(DisableBarrel());
        
    }*/
    IEnumerator DisableBarrel()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
        AssociatedPool.PutObject(gameObject);
    }
}
