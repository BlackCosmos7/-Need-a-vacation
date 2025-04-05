using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int collectibleCount = 0;
    public int requiredCollectibles = 15;//сколько надо набрать 
    public TextMeshProUGUI collectibleCounterText;

    public GameObject comicPanel;//комикс типа

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (collectibleCounterText != null)
        {
            collectibleCounterText.text = collectibleCount.ToString() + "/" + requiredCollectibles.ToString();
        }

        if (collectibleCount >= requiredCollectibles)
        {
            StartCoroutine(ShowComicAndLoadLevel());
        }
    }

    public void AddCollectible(int points)
    {
        collectibleCount += points;
    }

    private IEnumerator ShowComicAndLoadLevel()
    {
        if (comicPanel != null)
        {
            comicPanel.SetActive(true);
        }

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}