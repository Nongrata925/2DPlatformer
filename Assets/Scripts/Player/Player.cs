using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FruitCollector))]
public class Player : MonoBehaviour
{
    [SerializeField] private GroundDetector _groundDetector;

    private InputReader _inputReader;
    private Mover _mover;
    private Rotator _rotator;
    private Jumper _jumper;
    private PlayerAnimator _animator;
    private Rigidbody2D _rigidbody;
    
    private float _fallingThreshold = -0.1f;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
        _jumper = GetComponent<Jumper>();
        _animator = GetComponent<PlayerAnimator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsFalling())
        {
            _animator.StartFallAnimation();
        }
        else if (_groundDetector.IsGrounded())
        {
            _animator.StopFallAnimation();
        }

        if (_inputReader.Direction != 0)
        {
            _animator.StartMoveAnimation();
            _rotator.Rotate(_inputReader.Direction);
        }
        else
        {
            _mover.StopMove();
            _animator.StopMoveAnimation();
        }
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGrounded())
        {
            _animator.StartJumpAnimation();
            _jumper.Jump();
        }
    }

    private bool IsFalling()
    {
        return _rigidbody.velocity.y < _fallingThreshold && _groundDetector.IsGrounded() == false;
    }
}