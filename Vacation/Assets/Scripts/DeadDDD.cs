using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadDDD : MonoBehaviour
{
    public void RetryA()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game 1");
    }

    public void GoToMenuA()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

