﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaRefill : MonoBehaviour
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
            player.RechargeSprint(1000);
            gameObject.SetActive(false);
        }
            

    }
}
