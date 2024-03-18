using System;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    [HideInInspector] public Agent Agent;

    private Rigidbody2D _rigidbody;

    #region

    [SerializeField] private float jumpPower = 10f;
    [SerializeField] private float moveSpeed = 20f;

    #endregion

    [SerializeField] private float Gravity = -9.8f;
    private float v_velocity = 0;

    private float _moveDirection = 0;
    [SerializeField] private LayerMask whatIsGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        _rigidbody.velocity = new Vector2(_moveDirection * moveSpeed, v_velocity);
    }

    public bool isFall()
    {
        return _rigidbody.velocity.y < -0.1f;
    }

    public bool IsGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.5f + 0.1f, whatIsGround).collider != null;
    }

    public void SetMove(float dir)
    {
        _moveDirection = dir;
        if (dir > 0)
        {
            SetDirection(false);
        }
        else if (dir < 0)
        {
            SetDirection(true);
        }

    }

    public void ApplyGravity()
    {
        if (IsGround() && v_velocity <= 0)
        {
            v_velocity = -0.03f;
        }
        else
        {
            v_velocity += Gravity + Time.fixedDeltaTime;
        }
    }

    public void SetDirection(bool LookLeft)
    {
        Agent.Animator.SetFlip(LookLeft);
    }

    public void Jump()
    {
        v_velocity = jumpPower;
    }

    public void StopImmediately()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}
