using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private readonly int _isMovingKeyHash = Animator.StringToHash("IsMoving");
    private readonly int _jumpKeyHash = Animator.StringToHash("Jump");
    private readonly int _fallKeyHash = Animator.StringToHash("IsFall");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
