using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwarfMove : MonoBehaviour
{

    public float speed;

    private bool jump = false;
    
    public float jumpForce;


    private Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
        }

        /*if (jump)
        {
            // on demande à la touche space de multiplier par 5 la force du saut par la vélocité
            rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jump = false;
        }
        rigidbody.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }*/

    }
}


