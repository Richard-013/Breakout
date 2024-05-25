using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject paddlePrefab;

    void Start()
    {
        // Create an instance of the paddle
        Instantiate(paddlePrefab, new Vector3(0f, 2f, -1.5f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
