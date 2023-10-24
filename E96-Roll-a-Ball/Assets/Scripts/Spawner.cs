using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float spawnTimeDelta = 0.2f;
    [SerializeField] private float velocity = 1.0f; // Units per second
    [SerializeField] private float changeDirectionTimeDelta = 4.0f;

    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private GameObject winTextObject;


    private float nextSpawnTime;
    private float nextChangeDirectionTime;
    private Vector3 direction;
    private float bounds;
    private int numChildren;

    // Start is called before the first frame update
    void Start()
    {
        ChangeDirection();
        CreateChild();
        winTextObject.SetActive(false);
        nextSpawnTime = spawnTimeDelta;
        nextChangeDirectionTime = changeDirectionTimeDelta;
        bounds = 10.0f - spawnTimeDelta * velocity;
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
            if (transform.position.x <= -bounds || transform.position.x >= bounds ||
                transform.position.z <= -bounds || transform.position.z >= bounds)
            {
                ChangeDirection();
                transform.position += direction;
            }

            CreateChild();
        }
    }

    /**
     * Picks a new random direction ensuring the direction is within bounds
     */
    private void ChangeDirection()
    {
        var directionX = Random.Range(transform.position.x >= -bounds ? -1f : 0f, transform.position.x <= bounds ? 1f : 0f);
        var directionZ = Random.Range(transform.position.z >= -bounds ? -1f : 0f, transform.position.z <= bounds ? 1f : 0f);

        SetDirection(directionX, directionZ);
    }

    private void SetDirection(float directionX, float directionZ)
    {
        direction = velocity * spawnTimeDelta * new Vector3(directionX, 0.0f, directionZ).normalized;
    }

    private void CreateChild()
    {
        var child = Instantiate(target, transform.position, Quaternion.identity);
        child.GetComponent<Rotator>().parent = this;
        numChildren++;

        countText.text = $"Weird Cubes to Eat: {numChildren}";
    }

    public void DestroyChild()
    {
        numChildren--;
        countText.text = $"Weird Cubes to Eat: {numChildren}";

        if (numChildren == 0)
        {
            winTextObject.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
