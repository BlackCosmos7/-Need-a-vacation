using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatButton : MonoBehaviour
{
    public GameObject[] platformsToHide;
    public float delay = 0.5f;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            StartCoroutine(HidePlatforms());
        }
    }

    private System.Collections.IEnumerator HidePlatforms()
    {
        yield return new WaitForSeconds(delay);

        foreach (GameObject platform in platformsToHide)
        {
            if (platform != null)
            {
                platform.SetActive(false);
            }
        }
    }
}