using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
            this.transform.parent.gameObject.GetComponent<BarrelComponent>().DisableBarrelCoroutine();

    }

}
