using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private FruitPool _fruitPool;

    private int _delay = 3;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isSpawned = true;
        
        var wait = new WaitForSeconds(_delay);

        while (isSpawned)
        {
            yield return new WaitUntil(() => _fruitPool.HasAvailablePoint);
            
            yield return wait;
            
            _fruitPool.TryGetFruit();
        }
    }
}
