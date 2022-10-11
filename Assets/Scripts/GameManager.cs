using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadVSCPUScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadVSPlayerScene()
    {
        SceneManager.LoadScene(2);
    }
}
