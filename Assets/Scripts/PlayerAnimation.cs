using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ChangeDirection(true, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ChangeDirection(false, true);
        }
        else
        {
            _animator.SetBool("CanRun", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetBool("IsGrounded", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("IsGrounded", false);
    }

    private void ChangeDirection(bool setFlipX, bool setRunAnimation)
    {
        _spriteRenderer.flipX = setFlipX;
        _animator.SetBool("CanRun", setRunAnimation);
    }
}
