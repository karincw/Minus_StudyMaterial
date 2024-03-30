using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Agent agent, string animName) : base(agent, animName)
    {
    }

    private float direction = 0.06f;

    public override void Enter()
    {
        base.Enter();
        _agent.Input.OnMovementEvent += HandleMovementEvent;
        _agent.Movement.Jump();
    }

    public override void Exit()
    {
        _agent.Input.OnMovementEvent -= HandleMovementEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_agent.Movement.IsFall())
        {
            _agent.ChangeState(PlayerFSMState.Fall);
        }

        _agent.Movement.SetMove(direction);
    }

    private void HandleMovementEvent(float movement)
    {
        direction = movement;
    }

}
