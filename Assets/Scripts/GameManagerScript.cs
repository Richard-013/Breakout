using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Prefab properties
    [SerializeField] public GameObject brickPrefab;
    [SerializeField] public GameObject ballPrefab;
    [SerializeField] public GameObject framePrefab;
    [SerializeField] public GameObject paddlePrefab;

    // Size of grid to fill with bricks
    private int numColumns = 15;
    private int numRows = 8;

    // Default brick dimensions
    private float xSize = 2;
    private float ySize = 1;

    // Default brick starting position
    private float xPosition = -14.35f;
    private float yPosition = 16.75f;
    private float zPosition = -1.5f;

    // Default brick gaps
    private float xGap = 0.05f;
    private float yGap = 0.05f;

    // Game Stats
    private int totalBricks = 0;
    private int totalBricksDestroyed = 0;
    private int currentScore = 0;
    private int lives = 0;


    void Start()
    {
        CreateLevel();
    }

    void Update()
    {
        
    }

    private void CreateLevel()
    {
        // Spawn the frame, ball, and paddle
        Instantiate(framePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(ballPrefab, new Vector3(0f, 4f, zPosition), Quaternion.identity);
        Instantiate(paddlePrefab, new Vector3(0f, 2f, -1.5f), Quaternion.identity);

        // Create the grid of bricks
        CreateBrickGrid();
    }

    private void CreateBrickGrid()
    {
        // Set the position for the first brick to be placed at
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
                GameObject newBrick = Instantiate(brickPrefab, new Vector3(currentX, currentY, zPosition), Quaternion.identity);
                newBrick.name = brickName;
                //newBrick.gameManagerScript = GetComponent<GameManagerScript>();

                // Moves the starting point for the next row of bricks downwards
                currentX = currentX + (xSize + xGap);

                // Track number of bricks created
                totalBricks++;
            }

            // Moves the starting point for the next row of bricks downwards
            currentY = currentY - (ySize + yGap);
        }
    }

    public void AddToScore(int scoreToAdd)
    {
        // Add to the current score total
        currentScore = currentScore + scoreToAdd;
        totalBricksDestroyed = totalBricksDestroyed + 1;
    }

    private void ResetScore()
    {
        // Reset the score to 0
        currentScore = 0;
    }

    public int GetCurrentScore()
    {
        // Returns the current score
        return currentScore;
    }
}
