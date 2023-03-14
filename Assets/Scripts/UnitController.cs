using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public LayerMask groundLayer; // Set this to the layer where your plane is located
    public float moveSpeed = 20f;
    private Camera mainCamera;
    private Vector3 destination;

    private void Start()
    {
        groundLayer = LayerMask.GetMask("Default");
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                destination = hit.point;
                destination.y = 1f;
            }
        }

        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            Vector3 direction = (destination - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}



