using System.Collections;
using UnityEngine;

public class EnemySpikes : MonoBehaviour
{
    [SerializeField] private float upDistance = 1f; //длина выдвижения шипов
    [SerializeField] private float upTime = 1f; // Столько шипы снаружи
    [SerializeField] private float downTime = 2f; // Столько шипы внутри
    [SerializeField] private float moveSpeed = 2f; //скорость

    private Vector3 initialPosition;
    private Vector3 upPosition;
    private bool isDeadly = false;

    public bool IsDeadly => isDeadly;

    private void Start()
    {
        initialPosition = transform.localPosition;
        upPosition = initialPosition + Vector3.up * upDistance;
        StartCoroutine(SpikeRoutine());
    }

    private IEnumerator SpikeRoutine()
    {
        while (true)
        {
            // Выдвигаем
            yield return MoveSpike(upPosition);
            isDeadly = true;
            yield return new WaitForSeconds(upTime);

            // Прячем
            yield return MoveSpike(initialPosition);
            isDeadly = false;
            yield return new WaitForSeconds(downTime);
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