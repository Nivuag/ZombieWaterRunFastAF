using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPowerUpComponent : MonoBehaviour
{

    public List<GameObject> oranges;
    public List<GameObject> potions;
    void Update()
    {
        foreach (var item in oranges)
        {
            if (!item.active)
            {
                StartCoroutine(Timer(item));
                
            }
        }
        foreach (var item in potions)
        {
            if (!item.active)
            {
                StartCoroutine(Timer(item));
            }
        }
    }
    IEnumerator Timer(GameObject item)
    {
        yield return new WaitForSeconds(1);
        item.SetActive(true);
    }

}
