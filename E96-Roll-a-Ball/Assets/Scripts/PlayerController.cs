using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 displacement;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(displacement * speed);
    }

    void OnMove(InputValue value)
    {
        var values = value.Get<Vector2>();
        displacement = new Vector3(values.x, 0.0f, values.y);
    }
}
