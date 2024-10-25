using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopMeteorMove : MonoBehaviour
{
    private float speed = -8f;
    private float spinSpeed = 20f;
    private int outOfBoundsz = 50;
    private int outOfBoundsx = 50;

    public AudioClip destroySound;
    private AudioSource audioSource;

    public GameObject smallerAsteroidPrefab; // Reference to smaller asteroid prefab
    private bool isOriginalAsteroid = true; // Flag to identify original asteroid


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float randomRot = Random.Range(-10f, 20f);
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, randomRot * Time.deltaTime);

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
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.left, Quaternion.identity).GetComponent<TopMeteorMove>().SetOriginal(false);
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.right, Quaternion.identity).GetComponent<TopMeteorMove>().SetOriginal(false);
        Instantiate(smallerAsteroidPrefab, transform.position + Vector3.forward, Quaternion.identity).GetComponent<TopMeteorMove>().SetOriginal(false);

        if (destroySound != null && audioSource != null)
        {
            Debug.Log("Playing destruction sound...");
            audioSource.PlayOneShot(destroySound);
        }

        // Destroy this asteroid
        Destroy(gameObject);
    }

    public void SetOriginal(bool original)
    {
        isOriginalAsteroid = original;
    }
}