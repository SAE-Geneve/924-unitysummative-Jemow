using System;
using System.Collections;
using UnityEngine;

public class FX : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3f;

    private void Start()
    {
        StartCoroutine(LifeTimeRoutine());
    }

    private IEnumerator LifeTimeRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
