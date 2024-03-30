using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Agent agent, string animName) : base(agent, animName)
    {
    }

    private float direction = 0.06f;

    public override void Enter()
    {
        base.Enter();
        _agent.Input.OnMovementEvent += HandleMovementEvent;
    }

    public override void Exit()
    {
        _agent.Input.OnMovementEvent -= HandleMovementEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_agent.Movement.IsGround())
        {
            _agent.ChangeState(PlayerFSMState.Idle);
        }

        _agent.Movement.SetMove(direction);
    }

    private void HandleMovementEvent(float movement)
    {
        direction = movement;
    }
}
