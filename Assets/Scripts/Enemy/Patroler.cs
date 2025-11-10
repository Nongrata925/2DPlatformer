using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
public class Patroler : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _waypoints;
    
    private EnemyAnimator _animator;
    private Mover _mover;
    private Rotator _rotator;
    
    private Vector2 _direction;
    
    private int _currentWaypointIndex;
    private float _distanceThreshold = 0.1f;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
        _mover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        Patrol();
    }

    private void FixedUpdate()
    {
        _mover.Move(_direction.x);
    }

    private void Patrol()
    {
        Vector2 currentPosition = transform.position;
        Vector2 target = _waypoints[_currentWaypointIndex].transform.position;
        _direction = (target - currentPosition).normalized;
        
        _rotator.Rotate(_direction.x);
        _animator.StartMoveAnimation();

        if ((target - currentPosition).sqrMagnitude < _distanceThreshold)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
        }
    }
}
