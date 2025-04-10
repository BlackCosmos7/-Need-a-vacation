using UnityEngine;

public class Final : MonoBehaviour
{
    public GameObject bedPanel;

    private void Start()
    {
        if (bedPanel != null)
        {
            bedPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bedPanel != null)
            {
                bedPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (bedPanel != null)
            {
                bedPanel.SetActive(false);
            }
        }
    }
}