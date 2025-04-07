using System.Collections;
using UnityEngine;

public class PlatformNoSee : MonoBehaviour
{
    public enum PlatformMode { AppearOnPress, DisappearOnPress }
    [Header("Режим работы платформы")]
    [SerializeField] private PlatformMode mode = PlatformMode.AppearOnPress;

    [Header("Платформы")]
    [SerializeField] private GameObject[] platforms;

    [Header("Время отображения / скрытия")]
    [SerializeField] private float visibilityDuration = 3f;

    [Header("Кулдаун")]
    [SerializeField] private float cooldownDuration = 1f;

    private bool canPressE = true;

    private void Start()
    {
        if (mode == PlatformMode.AppearOnPress)
        {
            SetPlatformVisibility(false);
        }
        else
        {
            SetPlatformVisibility(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPressE)
        {
            if (mode == PlatformMode.AppearOnPress)
            {
                ShowPlatformsTemporarily();
            }
            else
            {
                HidePlatformsTemporarily();
            }
        }
    }

    private void ShowPlatformsTemporarily()
    {
        SetPlatformVisibility(true);
        canPressE = false;
        StopAllCoroutines();
        StartCoroutine(HidePlatformsAfterDelay());
        StartCoroutine(CooldownForE());
    }

    private void HidePlatformsTemporarily()
    {
        SetPlatformVisibility(false);
        canPressE = false;
        StopAllCoroutines();
        StartCoroutine(ShowPlatformsAfterDelay());
        StartCoroutine(CooldownForE());
    }

    private IEnumerator HidePlatformsAfterDelay()
    {
        yield return new WaitForSeconds(visibilityDuration);
        SetPlatformVisibility(false);
    }

    private IEnumerator ShowPlatformsAfterDelay()
    {
        yield return new WaitForSeconds(visibilityDuration);
        SetPlatformVisibility(true);
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
                spriteRenderer.enabled = visible;

            if (collider != null)
                collider.enabled = visible;
        }
    }
}