using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void LateUpdate()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0), Space.Self);
    }
}
