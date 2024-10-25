using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float forwardMovement;

    public bool playerLife = true;
    public int carDrivespeed;
    public int carTurnspeed;
    public int animTimer = 3;
    public bool playerMove;

    private int boundary = 70;

   
    //  public AudioClip throwSound;
    // AudioSource dog;
    public GameObject projectilePrefab;
    void start()
    {
        

    }

    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "Asteroid"
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Destroy the ship
            
            Destroy(gameObject);
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // You can add more game over logic here like showing game over screen, resetting the game, etc.
        }

        if (collision.gameObject.CompareTag("SmallAsteroid"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


    }
    // Update is called once per frame
    void Update()
    {
        // Set user input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardMovement = Input.GetAxis("Vertical");

        // Move the car forward and backward with Time.deltaTime
        transform.Translate(-forwardMovement * carDrivespeed * Time.deltaTime, 0, 0);

        // Rotate the car with Time.deltaTime
        transform.Rotate(0, horizontalInput * carTurnspeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(projectilePrefab, offset, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }



    // OnTriggerExit is called when the Collider other has stopped touching the trigger
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called");
        // Check if the ship has exited the left boundary
        if (transform.position.x <= -20 && other.CompareTag("wall"))
        {
            // Teleport the ship to the right boundary
            transform.position = new Vector3(24, transform.position.y, transform.position.z);
        }

        // Check if the ship has exited the right boundary
        if (transform.position.x >= 25 && other.CompareTag("wall"))
        {
            // Teleport the ship to the left boundary
            transform.position = new Vector3(-19, transform.position.y, transform.position.z);
        }

        // Check if the ship has exited the bottom boundary
        if (transform.position.z <= -49 && other.CompareTag("wall"))
        {
            // Teleport the ship to the top boundary
            transform.position = new Vector3(transform.position.x, transform.position.y, 26);
        }

        // Check if the ship has exited the top boundary
        if (transform.position.z > 27 && other.CompareTag("wall"))
        {
            // Teleport the ship to the bottom boundary
            transform.position = new Vector3(transform.position.x, transform.position.y, -47);
        }
    }
   // public void PlaySound(AudioClip clip)
   // {
   //     audioSource.PlayOneShot(clip);
   // }

}