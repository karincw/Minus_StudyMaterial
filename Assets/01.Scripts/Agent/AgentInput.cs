using System;
using UnityEngine;

public class AgentInput : MonoBehaviour
{

    public event Action<float> OnMovementEvent;
    public event Action<bool> OnJumpEvent;

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float direction;
        direction = Input.GetAxisRaw("Horizontal");
        OnMovementEvent?.Invoke(direction);
    }

    private void Jump()
    {
        //Change  GetKeyDown -> GetKey
        if (Input.GetKey(KeyCode.Space))
        {
            OnJumpEvent?.Invoke(true);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            OnJumpEvent?.Invoke(false);
        }
    }
    
}
