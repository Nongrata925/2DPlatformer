using UnityEngine;

public class FruitCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Fruit fruit))
        {
            fruit.Collect();
        }
    }
}
