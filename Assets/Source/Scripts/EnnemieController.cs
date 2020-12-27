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
}
