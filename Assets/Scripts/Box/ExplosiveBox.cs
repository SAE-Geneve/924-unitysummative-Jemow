using System.Collections;
using UnityEngine;

public class ExplosiveBox : Box
{
    [Header("Explosive")]
    [Tooltip("The explosive material")]
    [SerializeField] private Material _explosiveMaterial;
    
    [Tooltip("Another explosive material")]
    [SerializeField] private Material _explosiveMaterial2;
    
    [Tooltip("The amount of time before exploding when takinbg")]
    [SerializeField] private float _timeToExplode = 3f;
    
    [Tooltip("The explosion FX to play when destroyed")]
    [SerializeField] private FX _destroyFX;
    
    private MeshRenderer _meshRenderer;
    
    
    protected override void Start()
    {
        base.Start();
        
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public override void OnTake()
    {
        StartCoroutine(ExplodeRoutine());
        StartCoroutine(MaterialSwitchRoutine());
    }

    private IEnumerator ExplodeRoutine()
    {
        yield return new WaitForSeconds(_timeToExplode);
        
        Instantiate(_destroyFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator MaterialSwitchRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        _meshRenderer.material = _explosiveMaterial;
        yield return new WaitForSeconds(0.15f);
        _meshRenderer.material = _explosiveMaterial2;
        
        StartCoroutine(MaterialSwitchRoutine());
    }
}
