using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private float direction;

    public PlayerIdleState(Agent agent, string animName) : base(agent, animName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _agent.Input.OnMovementEvent += HandleMovementEvent;
        _agent.Input.OnJumpEvent += HandleJumpEvent;
        _agent.Movement.StopImmediately();
    }

    public override void Exit()
    {
        _agent.Input.OnMovementEvent -= HandleMovementEvent;
        _agent.Input.OnJumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_agent.Movement.IsFall())
        {
            _agent.ChangeState(PlayerFSMState.Fall);
        }

        //Change
        if (Mathf.Abs(direction) >= 0.05f)
        {
            _agent.ChangeState(PlayerFSMState.Run);
        }
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
