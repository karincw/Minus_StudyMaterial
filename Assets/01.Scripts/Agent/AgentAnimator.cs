using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    [HideInInspector] public Agent Agent;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAnimation(string animName, bool value)
    {
        _animator.SetBool(animName, value);
    }

    public void SetFlip(bool lookLeft)
    {
        _spriteRenderer.flipX = lookLeft;
    }

}
