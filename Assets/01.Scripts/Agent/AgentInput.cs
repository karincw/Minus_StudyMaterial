using System;
using UnityEngine;

public class AgentInput : MonoBehaviour
{

    public event Action<Vector2> MovementEvent;
    public event Action JumpEvent;
    public event Action DashEvent;

    private void Update()
    {
        Movement();
        Jump();
        Dash();
    }

    private void Movement()
    {
        Vector2 direction = Vector2.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        MovementEvent?.Invoke(direction.normalized);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpEvent?.Invoke();
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashEvent?.Invoke();
        }
    }

}
