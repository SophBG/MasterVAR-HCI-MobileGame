using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public float minDelay;
    public float maxDelay;

    private void Start()
    {
        Invoke("Spawn", Random.Range(minDelay, maxDelay));
    }

    private void Spawn()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab);
        newObstacle.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Invoke("Spawn", Random.Range(minDelay, maxDelay));
    }
}
