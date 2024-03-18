using UnityEngine;

public abstract class AgentState
{
    protected Agent _agent;
    protected int _animBoolHash;

    public virtual void Enter()
    {
        _agent.Animator.SetAnimation(_animBoolHash, true);
    }
    public virtual void Exit()
    {
        _agent.Animator.SetAnimation(_animBoolHash, false);
    }
    public abstract void UpdateState();

    public AgentState(Agent agent, string HashName)
    {
        _agent = agent;
        _animBoolHash = Animator.StringToHash(HashName);
    }
}
