using UnityEngine;

public class BrickScript : MonoBehaviour
{
    private GameManagerScript gameManagerScript;

    void Awake()
    {
        gameManagerScript = GameObject.FindAnyObjectByType(typeof(GameManagerScript)) as GameManagerScript;
        Debug.Log(gameManagerScript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManagerScript.AddToScore(100);
        Destroy(gameObject);
    }
}
