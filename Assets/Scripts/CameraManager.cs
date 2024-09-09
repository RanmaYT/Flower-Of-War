using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform playerPos;
    public float smoothTime = 0.25f;
    public Vector3 offset = new Vector3(0, 0, -10);
    public Vector3 velocity = Vector3.zero;

    private void Start()
    {
        transform.position = playerPos.position + offset;
    }

    void LateUpdate()
    {
        Vector3 desiredPos = playerPos.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPos, ref velocity, smoothTime);
    }
}
