using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public Rigidbody paddleRigidbody;

    private float moveSpeed = 5f;
    private float moveDirection;

    public InputActionReference movementInput;

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementInput.action.ReadValue<float>();
    }

    void FixedUpdate()
    {
        paddleRigidbody.linearVelocity = new Vector3(moveDirection * moveSpeed, 0, 0);
    }
}
