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
    private Vector2 _direction;

    private void Update()
    {
        if(_direction == Vector2.zero) return;
        
        transform.position += (transform.forward * _direction.y + transform.right * _direction.x) * (_speed * Time.deltaTime);
        _bodyTransform.forward = new Vector3(_direction.x, 0, _direction.y).normalized;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}
