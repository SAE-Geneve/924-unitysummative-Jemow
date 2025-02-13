using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private List<Box> _boxes = new List<Box>();

    public static BoxManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public void AddBox(Box box) => _boxes.Add(box);

    public void RemoveAllBoxes()
    {
        foreach (var box in _boxes)
        {
            Destroy(box.gameObject);
        }
    }
}
