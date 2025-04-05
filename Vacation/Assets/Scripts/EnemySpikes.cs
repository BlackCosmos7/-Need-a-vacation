using System.Collections;
using UnityEngine;

public class EnemySpikes : MonoBehaviour
{
    [SerializeField] private float upDistance = 1f; //����� ���������� �����
    [SerializeField] private float upTime = 1f; // ������� ���� �������
    [SerializeField] private float downTime = 2f; // ������� ���� ������
    [SerializeField] private float moveSpeed = 2f; //��������

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
            // ���������
            yield return MoveSpike(upPosition);
            isDeadly = true;
            yield return new WaitForSeconds(upTime);

            // ������
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