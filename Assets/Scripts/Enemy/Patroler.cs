using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _waypoints;

    private int _currentWaypointIndex;
    
    private float _distanceThreshold = 0.1f;

    public Vector2 GetDirection()
    {
        Vector2 currentPosition = transform.position;
        Vector2 target = _waypoints[_currentWaypointIndex].transform.position;
        Vector2 direction = (target - currentPosition).normalized;

        if ((target - currentPosition).sqrMagnitude < _distanceThreshold)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Count;
        }

        return direction;
    }
}