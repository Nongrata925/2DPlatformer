using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FruitPool : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private Fruit _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;

    private List<SpawnPoint> _availableSpawnPoints;

    private ObjectPool<Fruit> _pool;

    public bool HasAvailablePoint => _availableSpawnPoints.Count > 0;

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

        _availableSpawnPoints = new List<SpawnPoint>(_spawnPoints);
    }

    public void TryGetFruit()
    {
        if (HasAvailablePoint)
        {
            _pool.Get();
        }
    }

    private Fruit CreateFruit()
    {
        Fruit fruit = Instantiate(_prefab);

        return fruit;
    }

    private void ActivateFruit(Fruit fruit)
    {
        if (_availableSpawnPoints.Count == 0)
        {
            _pool.Release(fruit);
            return;
        }

        int randomIndex = Random.Range(0, _availableSpawnPoints.Count);
        SpawnPoint spawnPoint = _availableSpawnPoints[randomIndex];

        fruit.transform.position = spawnPoint.transform.position;
        fruit.Collected += ReleaseFruit;
        fruit.gameObject.SetActive(true);
        
        _availableSpawnPoints.Remove(spawnPoint);
        fruit.SetSpawnPoint(spawnPoint);
    }

    private void ReleaseFruit(Fruit fruit)
    {
        SpawnPoint spawnPoint = fruit.SpawnPoint;

        if (spawnPoint != null)
        {
            _availableSpawnPoints.Add(spawnPoint);
        }

        fruit.Collected -= ReleaseFruit;
        _pool.Release(fruit);
    }
}