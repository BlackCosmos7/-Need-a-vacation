using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlatform : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private bool isRotating = false;
    private float rotationAmount = 0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !isRotating)
        {
            StartCoroutine(RotatePlatform());
        }
    }

    private IEnumerator RotatePlatform()
    {
        isRotating = true;

        while (true)
        {
            rotationAmount += rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            if (rotationAmount > 360f)
            {
                break;
            }

            yield return null;
        }
        isRotating = false;
    }
}
