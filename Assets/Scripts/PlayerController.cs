using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 0;

    [SerializeField] Transform cameraTransform;
    [SerializeField] Light flashlight;

    private Rigidbody _rigidbody;
    private InputSystem_Actions inputActions;
    private Vector2 moveInput;
    [SerializeField] bool isFlashLightOn = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        inputActions = new InputSystem_Actions();

        inputActions.Player.Flash.performed += ctx => ToggleLight();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void ReadInput()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
    }


    private void HandleMovement()
    {
        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        Vector3 targetVelocity = moveDirection * speed;

        targetVelocity.y = _rigidbody.linearVelocity.y;

        _rigidbody.linearVelocity = targetVelocity;
    }

    private void ToggleLight()
    {
        isFlashLightOn = !isFlashLightOn;
        flashlight.enabled = isFlashLightOn;
    }
}

