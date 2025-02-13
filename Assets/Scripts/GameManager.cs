using System;
using System.Collections;
using TMPro;
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
    [Tooltip("The amount of time for the game")]
    [SerializeField] private float _gameTime = 120f;
    [Tooltip("The amount of time between each box spawn")]
    [SerializeField] private float _timeBetweenSpawns;
    
    [Header("UI")]
    [Tooltip("Reference to the BoxDeliveredTmp")]
    [SerializeField] private TMP_Text _boxDeliveredTmp;
    
    [Tooltip("Reference to the TimerTmp")]
    [SerializeField] private TMP_Text _timerTmp;
    
    public static GameManager Instance {get; private set;}

    private float _currentGameTime;
    private int _boxDelivered = 0;

    private void Awake()
    {
        if(Instance && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        _currentGameTime = _gameTime;
        StartCoroutine(BoxSpawnRoutine());
    } 

    private IEnumerator BoxSpawnRoutine()
    {
        yield return new WaitForSeconds(_timeBetweenSpawns);
        
        _boxSpawners[Random.Range(0, _boxSpawners.Length)].SpawnBox(_boxes[Random.Range(0, _boxes.Length)]);
        
        StartCoroutine(BoxSpawnRoutine());
    }

    private void Update()
    {
        UpdateTime();
    }

    private void UpdateTime()
    {
        _currentGameTime -= Time.deltaTime;
        _timerTmp.text = _currentGameTime.ToString("0.0");
    }

    public void AddBox()
    {
        _boxDelivered++;
        _boxDeliveredTmp.text = $"Box delivered : {_boxDelivered}";
    }
}