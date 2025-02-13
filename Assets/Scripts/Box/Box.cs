using UnityEngine;

public class Box : MonoBehaviour
{
    // public event Action OnBoxTake;

    public Rigidbody Rb { get; private set; }

    protected virtual void Start()
    {
        Rb = GetComponent<Rigidbody>();
        
        BoxManager.Instance.AddBox(this);
    }

    public virtual void OnTake()
    {
        
    }
}
