using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] public GameObject paddlePrefab;

    void Start()
    {
        Instantiate(paddlePrefab, new Vector3(0f, 2f, -1f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
