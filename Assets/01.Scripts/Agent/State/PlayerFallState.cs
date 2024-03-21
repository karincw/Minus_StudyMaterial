using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Agent agent, string animName) : base(agent, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_agent.Movement.IsGround())
        {
            _agent.ChangeState(PlayerFSMState.Idle);
        }
    }
}
