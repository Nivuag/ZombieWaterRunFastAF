using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healComponent : MonoBehaviour
{
    PlayerStatsManager player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerStatsManager>();
    }

    void OnTriggerEnter(Collider Collider)
    {
        if (Collider.tag == "Player")
        {
            
            gameObject.SetActive(false);
        }


    }
}
