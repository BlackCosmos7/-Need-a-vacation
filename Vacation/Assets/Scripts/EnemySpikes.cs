using System.Collections;
using UnityEngine;

public class EnemySpikes : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f; // Дистанция
    [SerializeField] private float moveTime = 1f; // Время двигаться
    [SerializeField] private float idleTime = 2f; // Время на месте
    [SerializeField] private float moveSpeed = 2f; // Скорость

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isDeadly = false;

    public bool IsDeadly => isDeadly;

    private void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = initialPosition + Vector3.right * moveDistance;
        StartCoroutine(SpikeRoutine());
    }

    private IEnumerator SpikeRoutine()
    {
        while (true)
        {
            yield return MoveSpike(targetPosition);
            isDeadly = true;
            yield return new WaitForSeconds(moveTime);

            yield return MoveSpike(initialPosition);
            isDeadly = false;
            yield return new WaitForSeconds(idleTime);
        }
    }

    private IEnumerator MoveSpike(Vector3 target)
    {
        while (Vector3.Distance(transform.localPosition, target) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}