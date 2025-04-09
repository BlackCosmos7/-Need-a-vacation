using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerTrapZone : MonoBehaviour
{
    public float trapDelay = 3f;
    public GameObject alertUI;

    private Coroutine trapCoroutine;
    private bool canKill = false;

    private void Start()
    {
        if (alertUI != null)
        {
            alertUI.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (trapCoroutine == null)
            {
                trapCoroutine = StartCoroutine(EnableTrap());
            }

            if (alertUI != null)
            {
                alertUI.SetActive(true);
            }

            if (canKill)
            {
                ExecuteDeath();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && canKill)
        {
            ExecuteDeath();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (trapCoroutine != null)
            {
                StopCoroutine(trapCoroutine);
                trapCoroutine = null;
                canKill = false;
            }

            if (alertUI != null)
            {
                alertUI.SetActive(false);
            }
        }
    }

    private IEnumerator EnableTrap()
    {
        yield return new WaitForSeconds(trapDelay);
        canKill = true;
    }

    private void ExecuteDeath()
    {
        SceneManager.LoadScene("Dead2");
    }
}