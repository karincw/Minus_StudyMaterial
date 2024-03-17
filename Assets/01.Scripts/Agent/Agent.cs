using System.Collections.Generic;
using UnityEngine;

public enum PlayerFSMSTate
{
    Idle = 1,
    Run = 2,
    Dash = 4,
    Jump = 8,
    Fall = 16,
    Hit = 32,
}

public class Agent : MonoBehaviour
{
    #region components

    [HideInInspector] public AgentMovement Movement;
    [HideInInspector] public AgentAnimator Animator;
    public AgentInput Input;

    #endregion

    public PlayerFSMSTate state = PlayerFSMSTate.Idle;

    public AgentState CurrentState;
    public Dictionary<PlayerFSMSTate, AgentState> AgentFSM = new Dictionary<PlayerFSMSTate, AgentState>();

    private void Awake()
    {
        var visualTrm = transform.Find("Visual");
        Movement = GetComponent<AgentMovement>();
        Movement.Agent = this;
        Animator = visualTrm.GetComponent<AgentAnimator>();
        Animator.Agent = this;

        #region StateInit

        AgentFSM.Add(PlayerFSMSTate.Idle, new IdleState(this, "Idle"));
        AgentFSM.Add(PlayerFSMSTate.Run, new RunState(this, "Run"));
        AgentFSM.Add(PlayerFSMSTate.Jump, new JumpState(this, "Jump"));
        AgentFSM.Add(PlayerFSMSTate.Fall, new FallState(this, "Fall")); ;
        AgentFSM.Add(PlayerFSMSTate.Dash, new DashState(this, "Dash")); ;
        AgentFSM.Add(PlayerFSMSTate.Hit, new HitState(this, "Hit")); ;

        #endregion
    }

    private void Update()
    {
        CurrentState.UpdateState();
    }

    public void ChangeState(PlayerFSMSTate nextState)
    {
        CurrentState.Exit();
        CurrentState = AgentFSM[nextState];
        CurrentState.Enter();
    }

}
