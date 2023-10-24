using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 displacement;
    public float speed = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
            Destroy(other.gameObject);
    }

    private void FixedUpdate()
    {
        rigidBody.AddForce(displacement * speed);
    }

    private void OnMove(InputValue value)
    {
        var values = value.Get<Vector2>();
        displacement = new Vector3(values.x, 0.0f, values.y);
    }
}