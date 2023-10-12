using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        var cachedTransform = transform;
        cachedTransform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        var pos = cachedTransform.position;
        var newY = Mathf.Sin(Time.time * 2.0f) * 0.00015f + pos.y;
        cachedTransform.position = new Vector3(pos.x, newY, pos.z);
    }
}
