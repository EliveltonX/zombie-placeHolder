using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    private Vector3 cameraOffset;
    public Transform Target;

    void Start()
    {
        cameraOffset = transform.position - Target.position;
    }

    
    void Update()
    {
        transform.position = Target.position + cameraOffset;

    }
}
