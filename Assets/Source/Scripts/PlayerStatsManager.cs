using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager: MonoBehaviour
{
    public bool isAlive = true;

    public float heal;

    public bool canSprint = true;

    public const float MIN_SPRINT_DURATION = 0;
    // En secondes
    public float sprintDuration = 10;
    // Per seconds
    public float sprintRechargeRate = 2;

    private float currentSprintCharge;

    private void Start() => heal = 1;

    public float CurrentSprintCharge {
        get { return currentSprintCharge; }
        private set{
            if (value < MIN_SPRINT_DURATION) currentSprintCharge = 0;
            else if (value >= sprintDuration) currentSprintCharge = sprintDuration;
            else currentSprintCharge = value;
        }
    }

    public void RechargeSprint(float amountToCharge)
    {
        CurrentSprintCharge += amountToCharge;
    }

    public void RechargeSprint()
    {
        CurrentSprintCharge += sprintRechargeRate * Time.deltaTime;
    }

    public void EmptySprint(float amountToEmpty)
    {
        CurrentSprintCharge -= amountToEmpty;
    }

    public void FullyRechargeSprint()
    {
        CurrentSprintCharge = sprintDuration;
    }

    public void FullyEmptySprint()
    {
        CurrentSprintCharge = MIN_SPRINT_DURATION;
    }

    

}
