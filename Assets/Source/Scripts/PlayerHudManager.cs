using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudManager : MonoBehaviour
{
        float scoreValue = 0;

        public bool death = false;
        public GameObject staminaBar;
        private Slider slider;
        private PlayerStatsManager playerStats;

        void Awake()
        {
            slider = staminaBar.GetComponent<Slider>();
            playerStats = GameObject.Find("Player").GetComponent<PlayerStatsManager>();
        }

        // Update is called once per frame
        void Update()
        {
            slider.value = playerStats.CurrentSprintCharge / playerStats.sprintDuration;
            
        }


}
