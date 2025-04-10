using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigZoneE : MonoBehaviour
{
    public float activationDelay = 3f;
    public GameObject warningUI;

    private Coroutine activationRoutine;
    private bool isHazardActive = false;

    private void Start()
    {
        if (warningUI != null)
        {
            warningUI.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (activationRoutine == null)
            {
                activationRoutine = StartCoroutine(ActivateHazard());
            }

            if (warningUI != null)
            {
                warningUI.SetActive(true);
            }

            if (isHazardActive)
            {
                TriggerPlayerDeath();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && isHazardActive)
        {
            TriggerPlayerDeath();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (activationRoutine != null)
            {
                StopCoroutine(activationRoutine);
                activationRoutine = null;
                isHazardActive = false;
            }

            if (warningUI != null)
            {
                warningUI.SetActive(false);
            }
        }
    }

    private IEnumerator ActivateHazard()
    {
        yield return new WaitForSeconds(activationDelay);
        isHazardActive = true;
    }

    private void TriggerPlayerDeath()
    {
        SceneManager.LoadScene("Dead3");
    }
}