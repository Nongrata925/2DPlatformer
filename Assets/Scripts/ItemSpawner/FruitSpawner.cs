using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Fruit _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;

    private int _delay = 3;
    
    private int _currentPositionIndex;

    private ObjectPool<Fruit> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Fruit>(
            createFunc: CreateFruit,
            actionOnGet: (fruit) => ActivateFruit(fruit),
            actionOnRelease: (fruit) => fruit.gameObject.SetActive(false),
            actionOnDestroy: (fruit) => Destroy(fruit.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private Fruit CreateFruit()
    {
        Fruit fruit = Instantiate(_prefab);

        return fruit;
    }

    private void ActivateFruit(Fruit fruit)
    {
        fruit.transform.position = GetSpawnPosition();
        fruit.Collected += ReleaseFruit;
        fruit.gameObject.SetActive(true);
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            _pool.Get();
            yield return wait;
        }
    }

    private void ReleaseFruit(Fruit fruit)
    {
        fruit.Collected -= ReleaseFruit;
        _pool.Release(fruit);
    }

    private Vector2 GetSpawnPosition()
    {
        _currentPositionIndex = (_currentPositionIndex + 1) % _spawnPoints.Count;

        return _spawnPoints[_currentPositionIndex].transform.position;
    }
}