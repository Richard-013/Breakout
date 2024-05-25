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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the information about the collision
        ContactPoint2D contact = collision.GetContact(0);

        // Check if collision has a valid Rigidbody2D
        // Avoids trying to apply velocity to walls
        if(collision.rigidbody == null)
        {
            return;
        }

        Vector2 collisionVelocity = collision.rigidbody.velocity;

        if(collisionVelocity[0] > 0)
        {
            // If the ball is moving to the right, bounce to the right
            Vector2 bounceDirection = new Vector2(5, collisionVelocity[1]);
            collision.rigidbody.velocity = bounceDirection;
        }
        else if(collisionVelocity[0] < 0)
        {
            // If the ball is moving to the left, bounce to the left
            Vector2 bounceDirection = new Vector2(-5, collisionVelocity[1]);
            collision.rigidbody.velocity = bounceDirection;
        }
        else
        {
            // Fallback logic if ball is bouncing directly down but does not hit the middle
            // of the paddle
            if (contact.point.x > transform.position.x)
            {
                // If the ball is hits the right of the paddle, bounce to the right
                Vector2 bounceDirection = new Vector2(5, collisionVelocity[1]);
                collision.rigidbody.velocity = bounceDirection;
            }
            else if (contact.point.x < transform.position.x)
            {
                // If the ball is hits the left of the paddle, bounce to the left
                Vector2 bounceDirection = new Vector2(-5, collisionVelocity[1]);
                collision.rigidbody.velocity = bounceDirection;
            }
        }
    }
}
