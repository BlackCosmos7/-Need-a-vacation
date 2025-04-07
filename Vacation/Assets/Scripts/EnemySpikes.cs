using System.Collections;
using UnityEngine;

public class EnemySpikes : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f; // Дистанция движения шипов влево-вправ
    [SerializeField] private float moveTime = 1f; // Время, сколько шипы будут двигаться в одну сторону
    [SerializeField] private float idleTime = 2f; // Время, сколько шипы будут "стоять" на месте
    [SerializeField] private float moveSpeed = 2f; // Скорость движения

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isDeadly = false;

    public bool IsDeadly => isDeadly;

    private void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = initialPosition + Vector3.right * moveDistance; // Двигаемся по оси X
        StartCoroutine(SpikeRoutine());
    }

    private IEnumerator SpikeRoutine()
    {
        while (true)
        {
            // Двигаем шипы в сторону цели (вправо)
            yield return MoveSpike(targetPosition);
            isDeadly = true;
            yield return new WaitForSeconds(moveTime); // Время, сколько шипы остаются в этой позиции

            // Двигаем шипы обратно (влево)
            yield return MoveSpike(initialPosition);
            isDeadly = false;
            yield return new WaitForSeconds(idleTime); // Время, сколько шипы будут в исходной позиции
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