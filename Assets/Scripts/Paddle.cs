using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D paddleRigidbody;

    private float moveSpeed = 5f;
    private float moveDirection = 0f;

    public InputActionReference movementInput;

    // Update is called once per frame
    void Update()
    {
        // Read the move direction from the input system
        moveDirection = movementInput.action.ReadValue<float>();
    }

    void FixedUpdate()
    {
        // Apply movement direction to the velocity of the ball
        paddleRigidbody.velocityX = moveSpeed * moveDirection;
    }

    }
}
