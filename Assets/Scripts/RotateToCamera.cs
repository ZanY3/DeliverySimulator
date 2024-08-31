using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    private Camera cam;
    private Transform camTransform;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("CameraMain").GetComponent<Camera>();
        camTransform = cam.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + camTransform.forward);
    }
}
