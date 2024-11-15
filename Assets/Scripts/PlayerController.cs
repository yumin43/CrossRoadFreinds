using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody _rigidbody;

    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;       
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)          // 키가 눌렸을 때(.Started는 키가 눌린 순간에 한 번만 작동됨)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)    // 키가 떨어졌을 때
        {
            curMovementInput = Vector2.zero;
        }
    }

}
