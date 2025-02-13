using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The box spawners in the scene")]
    [SerializeField] private BoxSpawner[] _boxSpawners;
    
    [Tooltip("All type of box")]
    [SerializeField] private Box[] _boxes;
    
    [Header("Parameters")]
    [Tooltip("The amount of time between each box spawn")]
    [SerializeField] private float _timeBetweenSpawns;

    private void Start() => StartCoroutine(BoxSpawnRoutine());

    private IEnumerator BoxSpawnRoutine()
    {
        yield return new WaitForSeconds(_timeBetweenSpawns);
        
        _boxSpawners[Random.Range(0, _boxSpawners.Length)].SpawnBox(_boxes[0]);
        
        StartCoroutine(BoxSpawnRoutine());
    }
}