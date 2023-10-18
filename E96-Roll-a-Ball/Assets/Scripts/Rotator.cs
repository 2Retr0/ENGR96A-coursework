using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 origin;
    private void Start()
    {
        origin = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var cachedTransform = transform;
        // cachedTransform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        cachedTransform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        var pos = cachedTransform.position;
        var newY = Mathf.Sin(Time.time * 2.0f) * 0.25f + origin.y;
        cachedTransform.position = new Vector3(pos.x, newY, pos.z);
    }
}
