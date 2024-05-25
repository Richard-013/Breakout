using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;

    private float moveSpeed = 6f;

    void Awake()
    {
        // Begin moving the ball downwards when it spawns in
        ballRigidbody.velocityY = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
