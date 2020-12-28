using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerComponent : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void Game() => SceneManager.LoadScene("New officiel");
    public void MainMenue() => SceneManager.LoadScene("MainMenue");
    public void Retry() => SceneManager.LoadScene("New officiel");
    
}
