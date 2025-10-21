using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWithArrowKeys : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 45.0f;

    private float horizontalInput;

    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Only get alternative input for horizontal (A and D keys)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }
        else
        {
            horizontalInput = 0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1f;
        }
        else
        {
            horizontalInput = 0f;
        }

        // Only get alternative input for vertical (W and S keys)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            forwardInput = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            forwardInput = -1f;
        }
        else
        {
            forwardInput = 0f;
        }

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * 20 * forwardInput);
        // Rotate the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}