using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _animator;
    
    private int _isMovingKeyHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        _isMovingKeyHash = Animator.StringToHash("IsMoving");
    }

    public void StartMoveAnimation()
    {
        _animator.SetBool(_isMovingKeyHash, true);
    }
}
