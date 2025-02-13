using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    public event Action OnBoxTake;
    
    public void OnTake() => OnBoxTake?.Invoke();
}
