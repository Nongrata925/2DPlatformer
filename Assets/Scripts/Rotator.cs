using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] SpriteRenderer _spriteRenderer;

    public void Rotate(float direction)
    {
        if (direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
