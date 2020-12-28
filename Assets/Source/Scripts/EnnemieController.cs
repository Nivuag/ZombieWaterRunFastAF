﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemieController : MonoBehaviour, IPoolable
{
    public GameObject Player;

    public NavMeshAgent thisAgent;

    public ObjectsPoolComponent AssociatedPool { get; set; }

    

    void Update()
    {
        thisAgent.SetDestination(Player.transform.localPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //Player.GetComponent<PlayerStatsManager>().isAlive = false;
            Debug.Log(Player.GetComponent<PlayerStatsManager>().health);
            Player.GetComponent<PlayerStatsManager>().health -= 0.2f;
        }
    }
}
