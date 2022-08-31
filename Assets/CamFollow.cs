using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // camera smoothDamp version Maxens

    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 velocity = Vector3.zero;

    private Vector3 offset = new Vector3(0f, 0f, -10f);


    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
