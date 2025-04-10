using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int collectibleCount = 0;
    public int requiredCollectibles = 15; // сколько нужно
    public TextMeshProUGUI collectibleCounterText; // текст сбора

    public GameObject[] panels; // массив панелек
    private int currentPanelIndex = 0;

    public GameObject platformToHide; // скрытая

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

        if (collectibleCount >= requiredCollectibles && currentPanelIndex == 0)
        {
            ShowPanel();
        }
    }

    public void AddCollectible(int points)
    {
        collectibleCount += points;
    }

    private void ShowPanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
        }
    }

    public void NextPanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }

        currentPanelIndex++;

        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }
        if (platformToHide != null)
        {
            platformToHide.SetActive(false);
        }
    }
}