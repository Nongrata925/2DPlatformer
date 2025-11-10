using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] LayerMask _ground;
    
    private bool _isGround;
    private float _rayDistance = 0.6f;

    public bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, _rayDistance, _ground);
    }
}
