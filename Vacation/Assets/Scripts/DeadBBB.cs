using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadBBB : MonoBehaviour
{
    public void RetryB()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game 2");
    }

    public void GoToMenuB()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
