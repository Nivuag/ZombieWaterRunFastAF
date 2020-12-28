using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerComponent : MonoBehaviour
{
    public void Game() => SceneManager.LoadScene("New officiel");
    public void MainMenue() => SceneManager.LoadScene("MainMenue");
    public void Retry()
    {
        
        Time.timeScale = 1;
        SceneManager.LoadScene("New officiel");
    }
}
