using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    private float _direction;
    private float _moveSpeed = 6.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _direction = direction;
        
        _rigidbody.velocity = new Vector2(_direction * _moveSpeed, _rigidbody.velocity.y);
    }

    public void StopMove()
    {
        _direction = 0;
        _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
    }
}
