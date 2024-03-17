using System;
using UnityEngine;

public class AgentInput : MonoBehaviour
{

    public event Action<float> MovementEvent;
    public event Action<bool> JumpEvent;
    public event Action DashEvent;

    private void Update()
    {
        Movement();
        Jump();
        Dash();
    }

    private void Movement()
    {
        float direction;
        direction = Input.GetAxisRaw("Horizontal");
        MovementEvent?.Invoke(direction);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpEvent?.Invoke(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            JumpEvent?.Invoke(false);
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
