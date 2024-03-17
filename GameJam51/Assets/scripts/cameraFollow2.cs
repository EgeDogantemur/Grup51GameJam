using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] Transform target;

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition , ref velocity, smoothTime);
    }
}
