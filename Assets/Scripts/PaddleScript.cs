using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleScript : MonoBehaviour
{
    public Rigidbody2D paddleRigidbody;

    private float paddleMoveSpeed = 7f;
    private float ballDeflectionSpeed = 6f;
    private float moveDirection = 0f;
    private float thrustForce = 1f;

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
        paddleRigidbody.velocityX = paddleMoveSpeed * moveDirection;
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

        // Get the velocity of the ball on impact
        Vector2 collisionVelocity = collision.rigidbody.velocity;
        Vector2 bounceDirection = new Vector2(0, 0);

        if(collisionVelocity[0] > 0)
        {
            // If the ball is moving to the right, bounce to the right
            if(collisionVelocity[0] > 5)
            {
                bounceDirection[0] = collisionVelocity[0];
                bounceDirection[1] = collisionVelocity[1];
            }
            else
            {
                bounceDirection[0] = ballDeflectionSpeed;
                bounceDirection[1] = collisionVelocity[1];
            }

            collision.rigidbody.velocity = bounceDirection;
            collision.rigidbody.AddForce(Vector3.up * thrustForce, ForceMode2D.Impulse);
            
        }
        else if(collisionVelocity[0] < 0)
        {
            // If the ball is moving to the left, bounce to the left
            if(collisionVelocity[0] < -5)
            {
                bounceDirection[0] = collisionVelocity[0];
                bounceDirection[1] = collisionVelocity[1];
            }
            else
            {
                bounceDirection[0] = ballDeflectionSpeed;
                bounceDirection[1] = collisionVelocity[1];
            }
            
            collision.rigidbody.velocity = bounceDirection;
            collision.rigidbody.AddForce(Vector3.up * thrustForce, ForceMode2D.Impulse);
        }
        else
        {
            // Fallback logic if ball is bouncing directly down but does not hit the middle
            // of the paddle
            if (contact.point.x > transform.position.x)
            {
                // If the ball is hits the right of the paddle, bounce to the right
                bounceDirection[0] = ballDeflectionSpeed;
                bounceDirection[1] = collisionVelocity[1];
                collision.rigidbody.velocity = bounceDirection;
                collision.rigidbody.AddForce(Vector3.up * thrustForce, ForceMode2D.Impulse);
            }
            else if (contact.point.x < transform.position.x)
            {
                // If the ball is hits the left of the paddle, bounce to the left
                bounceDirection[0] = ballDeflectionSpeed;
                bounceDirection[1] = collisionVelocity[1];
                collision.rigidbody.velocity = bounceDirection;
                collision.rigidbody.AddForce(Vector3.up * thrustForce, ForceMode2D.Impulse);
            }
        }
    }
}
