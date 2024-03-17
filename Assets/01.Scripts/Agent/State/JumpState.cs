public class JumpState : AgentState
{
    private float moveDirection = 0;

    public JumpState(Agent agent, string HashName) : base(agent, HashName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _agent.Input.MovementEvent += HandleMovementEvent;
    }

    public override void Exit()
    {
        _agent.Input.MovementEvent -= HandleMovementEvent;
        base.Exit();
    }

    public override void UpdateState()
    {
        if (_agent.Movement.isFall == true)
        {
            _agent.ChangeState(PlayerFSMSTate.Fall);
        }

        _agent.Movement.SetMove(moveDirection);

    }

    private void HandleMovementEvent(float movement)
    {
        moveDirection = movement;
    }
}
