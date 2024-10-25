using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftmeteorMove : MonoBehaviour
{
    private float speed = 8f;
    private float spinSpeed = 10f;
    private int outOfBoundsz = 50;
    private int outOfBoundsx = 50;

    public GameObject smallerAsteroidPrefab; // Reference to smaller asteroid prefab
    private bool isOriginalAsteroid = true; // Flag to identify original asteroid

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        if (transform.position.z > outOfBoundsz)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > outOfBoundsx)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isOriginalAsteroid && other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            SplitAsteroid();
        }
    }

    void SplitAsteroid()
    {
        // Spawn smaller asteroids
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.left, Quaternion.identity).GetComponent<LeftmeteorMove>().SetOriginal(false);
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.right, Quaternion.identity).GetComponent<LeftmeteorMove>().SetOriginal(false);
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.forward, Quaternion.identity).GetComponent<LeftmeteorMove>().SetOriginal(false);

        // Destroy this asteroid
        Destroy(gameObject);
    }

    public void SetOriginal(bool original)
    {
        isOriginalAsteroid = original;
    }
}
