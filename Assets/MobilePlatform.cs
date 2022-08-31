using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public Transform startPoint;

    public Transform endPoint;

    [SerializeField]
    private float timeToReach = 5f;

    private float timerMovement = 0f;

    private bool isForward = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lerpPosition = Vector3.Lerp(startPoint.position, endPoint.position, timerMovement / timeToReach);

        transform.position = lerpPosition;

        if (isForward)
        {
            timerMovement += Time.deltaTime;

            if (timerMovement >= timeToReach)
            {
                isForward = false;
            }
        }
        else
        {
            timerMovement -= Time.deltaTime;

            if (timerMovement <= 0f)
            {
                isForward = true;
            }
        }


    }
}
