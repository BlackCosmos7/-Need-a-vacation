using System.Collections;
using UnityEngine;

public class PlatformNoSee : MonoBehaviour
{
    [Header("Исчезающие объекты")]
    [SerializeField] private GameObject[] platforms;

    [Header("Кулдаун")]
    [SerializeField] private float visibilityDuration = 3f;
    [SerializeField] private float cooldownDuration = 1f;

    private bool canPressE = true;

    private void Start()
    {
        SetPlatformVisibility(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPressE)
        {
            ShowPlatforms();
        }
    }

    private void ShowPlatforms()
    {
        SetPlatformVisibility(true);
        canPressE = false;
        StopAllCoroutines();
        StartCoroutine(HidePlatformsAfterDelay());
        StartCoroutine(CooldownForE());
    }

    private IEnumerator HidePlatformsAfterDelay()
    {
        yield return new WaitForSeconds(visibilityDuration);
        SetPlatformVisibility(false);
    }

    private IEnumerator CooldownForE()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canPressE = true;
    }

    private void SetPlatformVisibility(bool visible)
    {
        foreach (GameObject platform in platforms)
        {
            SpriteRenderer spriteRenderer = platform.GetComponent<SpriteRenderer>();
            Collider2D collider = platform.GetComponent<Collider2D>();

            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = visible;
            }

            if (collider != null)
            {
                collider.enabled = true;
            }
        }
    }
}