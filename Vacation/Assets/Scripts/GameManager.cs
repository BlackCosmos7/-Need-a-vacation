using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int collectibleCount = 0;
    public int requiredCollectibles = 15; // сколько нужно собрать
    public TextMeshProUGUI collectibleCounterText; // текст для отображения количества собранных предметов

    public GameObject[] panels; // Массив панелей
    private int currentPanelIndex = 0; // Индекс текущей панели

    public GameObject platformToHide; // Платформа, которую нужно скрыть

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
            ShowPanel(); // Показываем первую панель после сбора всех предметов
        }
    }

    public void AddCollectible(int points)
    {
        collectibleCount += points; // Увеличиваем количество собранных предметов
    }

    // Показывает текущую панель
    private void ShowPanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true); // Активируем текущую панель
        }
    }

    // Переход к следующей панели
    public void NextPanel()
    {
        // Скрываем текущую панель
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }

        // Переходим к следующей панели
        currentPanelIndex++;

        // Если следующая панель существует, показываем её
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
        }
    }

    // Закрывает текущую панель и скрывает платформу
    public void ClosePanel()
    {
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(false);
        }

        // Скрыть платформу при закрытии панели
        if (platformToHide != null)
        {
            platformToHide.SetActive(false); // Скрываем платформу
        }
    }
}