using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    public event Action OnBoxTake;

    public Rigidbody Rb { get; private set; }

    private void Start() => Rb = GetComponent<Rigidbody>();

    public void OnTake() => OnBoxTake?.Invoke();
}
