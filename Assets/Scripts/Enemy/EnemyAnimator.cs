using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private readonly int _isMovingKeyHash = Animator.StringToHash("IsMoving");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartMoveAnimation()
    {
        _animator.SetBool(_isMovingKeyHash, true);
    }
}
