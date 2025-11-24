using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public string wallTag;
    private ObstacleSpawner spawner;

    public void Initialize(ObstacleSpawner spawnerRef)
    {
        spawner = spawnerRef;
    }

    private void Update()
    {
        this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wallTag))
        {
            spawner.NotifyObstacleDestroyed();
            Destroy(this.gameObject);
        }
    }
}
