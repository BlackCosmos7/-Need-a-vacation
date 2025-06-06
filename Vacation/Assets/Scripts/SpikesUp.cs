using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesUp : MonoBehaviour
{
    [SerializeField] private float moveDistance = 1f; //������
    [SerializeField] private float moveTime = 1f; // ����� ������
    [SerializeField] private float idleTime = 2f; // ����� ����
    [SerializeField] private float moveSpeed = 2f; //��������

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isDeadly = false;

    public bool IsDeadly => isDeadly;

    private void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = initialPosition + Vector3.up * moveDistance; 
        StartCoroutine(VerticalSpikeRoutine());
    }

    private IEnumerator VerticalSpikeRoutine()
    {
        while (true)
        {
            // ��������� ���� �����
            yield return MoveSpikeY(targetPosition);
            isDeadly = true;
            yield return new WaitForSeconds(moveTime);

            // �������� ������� ����
            yield return MoveSpikeY(initialPosition);
            isDeadly = false;
            yield return new WaitForSeconds(idleTime);
        }
    }

    private IEnumerator MoveSpikeY(Vector3 target)
    {
        while (Vector3.Distance(transform.localPosition, target) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
