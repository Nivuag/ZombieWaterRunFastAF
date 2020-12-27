using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class ScoreComponent : MonoBehaviour
{
    float scoreValue = 0;
    private Text score;
    private Text finalScore;
    public bool death = false;
    public GameObject gameover;
    public GameObject textFinalScore;
    public GameObject textScore;
    private PlayerStatsManager playerStats;

    void Awake()
    {
        score = textScore.GetComponent<Text>();
        finalScore = textFinalScore.GetComponent<Text>();
        gameover.SetActive(false);
        textFinalScore.SetActive(false);
        playerStats = GameObject.Find("Player").GetComponent<PlayerStatsManager>();
    }

    void Update()
    {
        if (playerStats.isAlive)
        {
            scoreValue += Time.deltaTime;
            score.text = "Score : " + Mathf.Round(scoreValue);
        }
        else
        {
            gameover.SetActive(true);
            textFinalScore.SetActive(true);
            textScore.SetActive(false);
            finalScore.text = "Score final : " + Mathf.Round(scoreValue);

            Time.timeScale = 0;
        }
        
    }
}
