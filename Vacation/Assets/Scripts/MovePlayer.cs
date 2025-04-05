using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("��������� ��������")]
    [SerializeField] private float walkSpeed = 5f;  //�������� ������
    [SerializeField] private float fallSpeed = 5f;  //�������� �������
    [SerializeField] private float jumpForce = 10f; //������ ������

    private Vector2 input;
    private bool isMoving;
    private bool isFalling;
    private bool isJumping;

    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private SpriteRenderer characterSprite;

    void Start()
    {
        // �������� ����������
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleMovement();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        ApplyGravity();
    }

    private void HandleMovement()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), 0);
        isMoving = input.x != 0;
        isFalling = rb.velocity.y < 0;
        isJumping = rb.velocity.y > 0;

        //��������
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsFalling", isFalling);
        animator.SetBool("IsJumping", isJumping);

        if (isMoving)
        {
            characterSprite.flipX = input.x < 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling)
        {
            Jump();
        }
    }

    private void ApplyMovement()
    {
        float horizontalMovement = input.x * walkSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    private void ApplyGravity()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, -fallSpeed);
        }
    }

    private void Jump()
    {
        // ��������� ���� ������
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}