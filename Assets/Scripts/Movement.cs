using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [Space]
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(_speed * Time.deltaTime *-1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool("CanRun", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool("CanRun", true);
        }
        else
        {
            _animator.SetBool("CanRun", false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && _isGrounded == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _animator.SetBool("IsGrounded", true);
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _animator.SetBool("IsGrounded", false);
        _isGrounded = false;
    }
}