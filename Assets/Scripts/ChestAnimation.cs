using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ChestAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsReached", false);
    }

    private void OnTriggerEnter2D()
    {
        _animator.SetBool("IsReached", true);
    }
}
