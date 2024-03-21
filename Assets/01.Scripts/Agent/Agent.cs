using System.Collections.Generic;
using UnityEngine;

public enum PlayerFSMState
{
    Idle,
    Run,
    Jump,
    Fall
}

public class Agent : MonoBehaviour
{
    #region components

    [HideInInspector] public AgentMovement Movement;
    [HideInInspector] public AgentAnimator Animator;
    public AgentInput Input;

    private PlayerFSMState state = PlayerFSMState.Idle;
    private PlayerState currentState;
    private Dictionary<PlayerFSMState, PlayerState> stateMachine = new();

    #endregion

    private void Awake()
    {
        var visualTrm = transform.Find("Visual");
        Movement = GetComponent<AgentMovement>();
        Movement.Agent = this;
        Animator = visualTrm.GetComponent<AgentAnimator>();
        Animator.Agent = this;

        stateMachine.Add(PlayerFSMState.Idle, new PlayerIdleState(this, "Idle"));
        stateMachine.Add(PlayerFSMState.Run, new PlayerRunState(this, "Run"));
        stateMachine.Add(PlayerFSMState.Jump, new PlayerJumpState(this, "Jump"));
        stateMachine.Add(PlayerFSMState.Fall, new PlayerFallState(this, "Fall"));
    }

    private void Start()
    {
        currentState = stateMachine[PlayerFSMState.Idle];
        currentState.Enter();
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void ChangeState(PlayerFSMState state)
    {
        currentState.Exit();
        currentState = stateMachine[state];
        this.state = state;
        currentState.Enter();
    }

}
