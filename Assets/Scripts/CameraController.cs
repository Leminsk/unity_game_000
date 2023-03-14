using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10.0f; // Speed of camera movement
    public float scrollSpeed = 10.0f; // Speed of camera zoom
    public float scrollMultiplier = 1000.0f; // make scroll easy 

    // control the camera's height
    public float minY = 50f;
    public float maxY = 1000f;

    // Update is called once per frame
    void Update()
    {
        
        // Get input from arrow keys
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        // Move the camera horizontally
        transform.position += new Vector3(xInput, 0, zInput) * moveSpeed * Time.deltaTime;

        // Check if mouse wheel is being used
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        if (scrollInput != 0) {
            // Update y position based on mouse wheel input
            float yInput = scrollInput * scrollSpeed * Time.deltaTime;
            yInput += scrollInput * scrollMultiplier;
            transform.position -= new Vector3(0, yInput, 0);
        } else {
            // Only update x and z positions if mouse wheel is not being used
            transform.position += new Vector3(xInput, 0, zInput);
        }

        // update positions
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
