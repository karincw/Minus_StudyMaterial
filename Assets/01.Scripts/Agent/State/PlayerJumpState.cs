using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Agent agent, string animName) : base(agent, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.Movement.Jump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        if(_agent.Movement.IsFall())
        {
            _agent.ChangeState(PlayerFSMState.Fall);
        }
    }
}
