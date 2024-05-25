using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numColumns = 15;
    private int numRows = 8;

    // Total number of bricks generated
    private int totalBricks = 0;

    [SerializeField] public GameObject brickPrefab;
    [SerializeField] public GameObject ballPrefab;
    [SerializeField] public GameObject framePrefab;

    // Default brick dimensions
    private float xSize = 2;
    private float ySize = 1;
    // private float zSize = 1;

    // Default brick starting position
    private float xPosition = -14.35f;
    private float yPosition = 16.75f;
    private float zPosition = -1.5f;

    // Default brick gaps
    private float xGap = 0.05f;
    private float yGap = 0.05f;

    void Start()
    {
        Instantiate(framePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(ballPrefab, new Vector3(0f, 4f, zPosition), Quaternion.identity);

        float currentX = xPosition;
        float currentY = yPosition;

        for(int row = 0; row < numRows; row++)
        {
            // Reset the starting point for placing bricks on the x-axis
            currentX = xPosition;

            for(int column = 0; column < numColumns; column++)
            {
                // Instantiate the brick object
                string brickName = "Brick-" + column + "-" + row;
                GameObject brick = Instantiate(brickPrefab, new Vector3(currentX, currentY, zPosition), Quaternion.identity);
                brick.name = brickName;

                // Moves the starting point for the next row of bricks downwards
                currentX = currentX + (xSize + xGap);

                // Track number of bricks created
                totalBricks++;
            }

            // Moves the starting point for the next row of bricks downwards
            currentY = currentY - (ySize + yGap);
        }
    }

    void Update()
    {
        
    }
}
