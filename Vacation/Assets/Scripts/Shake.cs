using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private float tiltAmount = 5f;  //наклон
    [SerializeField] private float shakeSpeed = 20f;  //скорость
    [SerializeField] private float shakeDuration = 2f;  //время тряски до конца

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private bool isShaking = false;

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isShaking && collision.collider.CompareTag("Player"))
        {
            StartCoroutine(ShakeRoutine());
        }
    }

    private IEnumerator ShakeRoutine()
    {
        isShaking = true;
        float timer = 0f;

        while (timer < shakeDuration)
        {
            float tilt = Mathf.Sin(Time.time * shakeSpeed) * tiltAmount;
            transform.localRotation = Quaternion.Euler(0, 0, tilt);
            transform.localPosition = initialPosition + new Vector3(tilt * 0.1f, tilt * 0.1f, 0);

            timer += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = initialPosition;
        transform.localRotation = initialRotation;

        isShaking = false;
    }
}