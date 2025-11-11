using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Patroller))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private Rotator _rotator;
    private Patroller _patroller;
    private EnemyAnimator _animator;
    
    private Vector2 _currentDirection;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
        _patroller = GetComponent<Patroller>();
        _animator = GetComponent<EnemyAnimator>();
    }
    
    private void FixedUpdate()
    {
        _mover.Move(_currentDirection.x);
    }

    private void Update()
    {
        Patrol();
        
        _rotator.Rotate(_currentDirection.x);
        _mover.Move(_currentDirection.x);
        _animator.StartMoveAnimation();
    }

    private void Patrol()
    {
        _currentDirection = _patroller.GetDirection();
    }
}
