using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    [HideInInspector] public Agent Agent;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimation(string animName, bool value)
    {

    }


}
