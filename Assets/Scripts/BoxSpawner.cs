using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private Box _boxToSpawn;

    private void Start()
    {
        Instantiate(_boxToSpawn, transform.position + new Vector3(1, 1, 0), Quaternion.identity, transform);
    }
}
