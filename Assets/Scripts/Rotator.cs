using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const float FlipRotationAngle = 180.0f;
    
    private Quaternion _lookRight = Quaternion.Euler(0, 0, 0);
    private Quaternion _lookLeft = Quaternion.Euler(0, FlipRotationAngle, 0);
    
    public void Rotate(float direction)
    {
        transform.rotation = direction > 0 ? _lookRight : _lookLeft;
    }
}