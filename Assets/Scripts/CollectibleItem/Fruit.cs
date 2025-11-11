using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public event Action<Fruit> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
    }
}