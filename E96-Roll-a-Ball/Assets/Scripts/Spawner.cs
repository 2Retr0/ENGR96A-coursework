using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float spawnTimeDelta = 0.2f;
    [SerializeField] private float velocity = 5.0f; // Units per second
    [SerializeField] private float changeDirectionTimeDelta = 4.0f;

    private float nextSpawnTime;
    private float nextChangeDirectionTime;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(target, transform.position, transform.rotation);
        ChangeDirection();
        nextSpawnTime = spawnTimeDelta;
        nextChangeDirectionTime = changeDirectionTimeDelta;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.fixedTime > nextChangeDirectionTime)
        {
            nextChangeDirectionTime += changeDirectionTimeDelta;
            ChangeDirection();
        }

        if (Time.fixedTime > nextSpawnTime)
        {
            nextSpawnTime += spawnTimeDelta;

            transform.position += direction;
            // Force change direction if position will be out of bounds!
            if (transform.position.x <= -9.5 || transform.position.x >= 9.5 ||
                transform.position.z <= -9.5 || transform.position.z >= 9.5)
            {
                ChangeDirection();
                transform.position += direction;
            }

            Instantiate(target, transform.position, Quaternion.identity);
        }
    }

    private void ChangeDirection()
    {
        var directionX = Random.Range(transform.position.x >= -9.5 ? -1f : 0f, transform.position.x <= 9.5 ? 1f : 0f);
        var directionZ = Random.Range(transform.position.z >= -9.5 ? -1f : 0f, transform.position.z <= 9.5 ? 1f : 0f);

        SetDirection(directionX, directionZ);
    }

    private void SetDirection(float directionX, float directionZ)
    {
        direction = velocity * spawnTimeDelta * new Vector3(directionX, 0.0f, directionZ).normalized;
    }
}
