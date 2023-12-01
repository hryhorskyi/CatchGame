using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce = 10f;

    private InputWrapper _input;
    private bool _paused;

    public bool IsGrounded { get; private set; }
    public float CurrentSpeed => _rigidbody2D.velocity.x;

    private void Awake()
    {
        _input = new InputWrapper();
    }

    private void Update()
    {
        if(_paused)
            return;
        
        var movementInput = _input.HorizontalMovement;
        _rigidbody2D.velocity = new Vector2(movementInput * _speed, _rigidbody2D.velocity.y);

        if (IsGrounded && _input.IsJumpPressed)
        {
            _rigidbody2D.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Unpause()
    {
        _paused = false;
    }
}