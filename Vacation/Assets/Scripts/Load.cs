using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider scale;

    public void Loading()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(1);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            float progress = Mathf.Clamp01(loadAsync.progress / 0.9f);
            scale.value = progress;

            if (loadAsync.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}