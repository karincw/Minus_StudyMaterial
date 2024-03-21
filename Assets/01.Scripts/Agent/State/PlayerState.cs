using UnityEngine;

public abstract class PlayerState
{
    protected Agent _agent;
    private string _animName;

    public virtual void Enter()
    {
        _agent.Animator.SetAnimation(_animName, true);
    }

    public virtual void Exit()
    {
        _agent.Animator.SetAnimation(_animName, false);
    }

    public abstract void UpdateState();

    public PlayerState(Agent agent, string animName)
    {
        _agent = agent;
        _animName = animName;
    }

}
