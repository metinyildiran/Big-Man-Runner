using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class Player : MonoBehaviour
{
    [SerializeField] private float touchMovementSensitivity = 0.02f;

    private TouchControls touchControls;

    private bool isMoving;
    [SerializeField] private float moveSpeedZ = 0.2f;

    private void Awake()
    {
        touchControls = new TouchControls();
    }

    private void Start()
    {
        touchControls.Player.Slide.started += context => OnTouchSlided(context);
        touchControls.Player.Move.started += context => OnTouchMoved(context);
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;

        transform.Translate(0, 0, moveSpeedZ);
    }

    private void OnTouchSlided(CallbackContext context)
    {
        var position = transform.position;

        position = new Vector3(position.x + (context.ReadValue<float>()) * touchMovementSensitivity,
            position.y, position.z);

        position.x = Mathf.Clamp(position.x, -4.2f, 4.2f);

        transform.position = position;
    }

    private void OnTouchMoved(CallbackContext context)
    {
        if (context.started)
        {
            isMoving = true;
        }
        else if (context.canceled)
        {
            isMoving = false;
        }
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
    }
}
