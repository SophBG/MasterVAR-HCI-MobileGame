using UnityEngine;
using UnityEngine.Events;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    [Header("Spawn Settings")]
    public Transform spawnPoint;
    public float minDelay;
    public float maxDelay;
    [Header("Events")]
    public UnityEvent OnDestroy;

    private void Start()
    {
        Invoke("Spawn", Random.Range(minDelay, maxDelay));
    }

    private void Spawn()
    {
        GameObject newObstacle = Instantiate(obstaclePrefab, transform);
        Obstacle obstacle = newObstacle.GetComponent<Obstacle>();
        obstacle.Initialize(this);
        newObstacle.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        Invoke("Spawn", Random.Range(minDelay, maxDelay));
    }

    public void NotifyObstacleDestroyed()
    {
        OnDestroy?.Invoke();
    }
}
