using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Agent agent, string animName) : base(agent, animName)
    {
    }

    private float direction = 0.06f;

    public override void Enter()
    {
        base.Enter();
        _agent.Input.OnMovementEvent += HandleMovementEvent;
        _agent.Input.OnJumpEvent += HandleJumpEvent;
    }

    public override void Exit()
    {
        _agent.Input.OnMovementEvent -= HandleMovementEvent;
        _agent.Input.OnJumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        //Change
        if (Mathf.Abs(direction) <= 0.05f)
        {
            _agent.ChangeState(PlayerFSMState.Idle);
        }

        _agent.Movement.SetMove(direction);

    }

    private void HandleJumpEvent(bool value)
    {
        if (value == true)
        {
            _agent.ChangeState(PlayerFSMState.Jump);
        }
    }

    //Change
    private void HandleMovementEvent(float movement)
    {
        direction = movement;
    }
}
