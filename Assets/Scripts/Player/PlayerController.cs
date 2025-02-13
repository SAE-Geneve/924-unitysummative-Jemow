using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The player body")]
    [SerializeField]
    private Transform _bodyTransform;
    
    [Header("Parameters")]
    [Tooltip("The speed of the player")] 
    [SerializeField]
    private float _speed = 10f;

    private Rigidbody _rb;
    private Vector3 _defaultPosition;
    private Vector2 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        if(_direction == Vector2.zero) return;
        
        _rb.position += transform.forward * (_direction.y * _speed * Time.deltaTime) + transform.right * (_direction.x * _speed * Time.deltaTime);
        _bodyTransform.forward = new Vector3(_direction.x, 0, _direction.y).normalized;
    }

    public void ResetPosition() => transform.position = _defaultPosition;
    
    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}
