using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private SpawnPoint _spawnPoint;

    public event Action<Fruit> Collected;

    public SpawnPoint SpawnPoint => _spawnPoint;

    public void SetSpawnPoint(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}