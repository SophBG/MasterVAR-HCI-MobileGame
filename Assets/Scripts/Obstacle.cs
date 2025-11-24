using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;
    public string wallTag;

    private void Update()
    {
        this.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(wallTag))
        {
            Destroy(this.gameObject);
        }
    }
}
