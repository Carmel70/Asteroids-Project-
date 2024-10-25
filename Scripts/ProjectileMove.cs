using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private float speed = 30f;
    private int outOfBoundsz = 50;
    private int outOfBoundsx = 50;
    public int numWarp = 0;

    private bool hasHitAsteroid = false; // Flag to prevent further actions after hitting an asteroid

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.z > outOfBoundsz || transform.position.z < -outOfBoundsz)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > outOfBoundsx || transform.position.x < -outOfBoundsx)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasHitAsteroid && other.CompareTag("SmallAsteroid"))
        {
            hasHitAsteroid = true;
            Destroy(other.gameObject);
            Debug.Log("You earned a point!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called");
        // Check if the ship has exited the left boundary
        if (transform.position.x <= -20 && other.CompareTag("wall"))
        {
            // Teleport the ship to the right boundary
            transform.position = new Vector3(24, transform.position.y, transform.position.z);

            if (numWarp > 0)
            {
                Destroy(gameObject);
            }

            numWarp += 1;
        }

        // Check if the ship has exited the right boundary
        if (transform.position.x >= 25 && other.CompareTag("wall"))
        {
            // Teleport the ship to the left boundary
            transform.position = new Vector3(-19, transform.position.y, transform.position.z);

            if (numWarp > 0)
            {
                Destroy(gameObject);
            }

            numWarp += 1;
        }

        // Check if the ship has exited the bottom boundary
        if (transform.position.z <= -49 && other.CompareTag("wall"))
        {
            // Teleport the ship to the top boundary
            transform.position = new Vector3(transform.position.x, transform.position.y, 22);

            if (numWarp > 0)
            {
                Destroy(gameObject);
            }

            numWarp += 1;
        }

        // Check if the ship has exited the top boundary
        if (transform.position.z > 23 && other.CompareTag("wall"))
        {
            // Teleport the ship to the bottom boundary
            transform.position = new Vector3(transform.position.x, transform.position.y, -47);

            if (numWarp > 0)
            {
                Destroy(gameObject);
            }

            numWarp += 1;
        }

    }
}