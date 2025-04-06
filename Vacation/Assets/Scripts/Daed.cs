using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Daed : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

