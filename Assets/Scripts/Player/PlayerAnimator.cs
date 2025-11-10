using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private int _isMovingKeyHash;
    private int _jumpKeyHash;
    private int _fallKeyHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        _isMovingKeyHash = Animator.StringToHash("IsMoving");
        _jumpKeyHash = Animator.StringToHash("Jump");
        _fallKeyHash = Animator.StringToHash("IsFall");
    }

    public void StartMoveAnimation()
    {
        _animator.SetBool(_isMovingKeyHash, true);
    }

    public void StopMoveAnimation()
    {
        _animator.SetBool(_isMovingKeyHash, false);
    }

    public void StartJumpAnimation()
    {
        _animator.SetTrigger(_jumpKeyHash);
    }

    public void StartFallAnimation()
    {
        _animator.SetBool(_fallKeyHash, true);
    }

    public void StopFallAnimation()
    {
        _animator.SetBool(_fallKeyHash, false);
    }
}
