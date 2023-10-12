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
    private int count = 0;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        winTextObject.SetActive(false);
        SetCountText();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }

        count++;
        SetCountText();
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

    private void SetCountText()
    {
        countText.text = $"Count: {count}";

        if (count >= 5)
        {
            winTextObject.SetActive(true);
        }
    }
}