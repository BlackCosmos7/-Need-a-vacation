using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlatform : MonoBehaviour
{
    public float deathDelay = 3f;
    public GameObject warningPanel;
    private bool isDeadly = false;
    private Coroutine deathCoroutine;

    private void Start()
    {
        if (warningPanel != null)
        {
            warningPanel.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Запускаем таймер
            if (deathCoroutine == null)
            {
                deathCoroutine = StartCoroutine(ActivateDeathZone());
            }

            if (warningPanel != null)
            {
                warningPanel.SetActive(true);
            }

            if (isDeadly)
            {
                KillPlayer();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && isDeadly)
        {
            KillPlayer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (deathCoroutine != null)
            {
                StopCoroutine(deathCoroutine);
                deathCoroutine = null;
                isDeadly = false;
            }

            if (warningPanel != null)
            {
                warningPanel.SetActive(false);
            }
        }
    }

    private IEnumerator ActivateDeathZone()
    {
        yield return new WaitForSeconds(deathDelay);
        isDeadly = true;
    }

    private void KillPlayer()
    {
        SceneManager.LoadScene("DeadScreen");
    }
}