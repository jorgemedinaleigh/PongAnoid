using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    GameObject[] players;

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    void EndGame()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length <= 1)
        {
            Time.timeScale = 0.1f;
            Invoke("LoadEndGameScene", 0.3f);
        }
    }

    public void LoadEndGameScene()
    {
        SceneManager.LoadScene(3);
    }
}
