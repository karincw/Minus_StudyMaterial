using System.Collections;
using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    [HideInInspector] public Agent Agent;

    private Animator _animator;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetAnimation(int Hash, bool state)
    {
        _animator.SetBool(Hash, state);
    }

    public void SetFlip(bool flip)
    {
        _renderer.flipX = flip;
    }

}
