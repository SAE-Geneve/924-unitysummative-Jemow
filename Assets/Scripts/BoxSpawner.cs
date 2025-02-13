using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _boxToSpawn;

    private Box _deliveredBox;

    private void Start()
    {
        _deliveredBox = Instantiate(_boxToSpawn, transform.position + new Vector3(1, 1, 0), Quaternion.identity, transform);
        _deliveredBox.OnBoxTake += BoxTaken;
    }

    private void Update()
    {
        Debug.Log(_deliveredBox);
    }

    public void BoxTaken() => _deliveredBox = null;
}
