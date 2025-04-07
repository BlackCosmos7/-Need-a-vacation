using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    public float disappearDelay = 1f;   //задержка перед исчезновением
    public float respawnTime = 3f;      //время до восстановления

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(DelayedHideAndRestore());
        }
    }

    private IEnumerator DelayedHideAndRestore()
    {
        yield return new WaitForSeconds(disappearDelay);
        HidePlatform();
        yield return new WaitForSeconds(respawnTime);
        ShowPlatform();
    }

    private void HidePlatform()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void ShowPlatform()
    {
        GetComponent<Collider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
