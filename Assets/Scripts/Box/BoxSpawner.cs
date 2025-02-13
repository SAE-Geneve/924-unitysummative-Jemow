using System.Collections;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Parameters ")]
    [Tooltip("Define the amount of unit to add to the box spawn position from the parent pivot")]
    [SerializeField] private Vector3 _spawnVector = new Vector3(1, 1, 0);
    
    [Tooltip("Define how much time the box will slide at the beginning")]
    [SerializeField] private float _slideTime = 0.5f;

    private Box _deliveredBox;

    private bool _sliding;

    private void Update()
    {
        if(_deliveredBox && _sliding)
            _deliveredBox.Rb.position += Vector3.right * Time.deltaTime;
    }

    public void SpawnBox(Box box)
    {
        _deliveredBox = Instantiate(box, transform.position + _spawnVector, Quaternion.identity, transform);
        _sliding = true;

        StartCoroutine(BoxSlideTime());
    }

    private IEnumerator BoxSlideTime()
    {
        yield return new WaitForSeconds(_slideTime);
        _sliding = false;
    }
}
