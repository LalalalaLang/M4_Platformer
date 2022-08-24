using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMove : MonoBehaviour
{

    public float speed = 20f;
    private bool jump;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (jump = true)
        {
            // on demande à la touche space de multiplier par 5 la force du saut par la vélocité
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jump = false;
        }
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }
}
}
