using UnityEngine;

public class IdleState : AgentState
{
    private float moveDirection = 0;

    public IdleState(Agent agent, string HashName) : base(agent, HashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.Input.MovementEvent += HandleMovementEvent;
        _agent.Input.JumpEvent += HandleJumpEvent;
        _agent.Movement.StopImmediately();
    }

    public override void Exit()
    {
        _agent.Input.MovementEvent -= HandleMovementEvent;
        _agent.Input.JumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        if (Mathf.Abs(moveDirection) >= 0.05f)
        {
            _agent.ChangeState(PlayerFSMSTate.Run);
        }
        else if (_agent.Movement.isFall == true)
        {
            _agent.ChangeState(PlayerFSMSTate.Fall);
        }
    }

    private void HandleMovementEvent(float movement)
    {
        moveDirection = movement;
    }
    private void HandleJumpEvent(bool State)
    {
        if (State == true)
            _agent.ChangeState(PlayerFSMSTate.Jump);
    }
}
