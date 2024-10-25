using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopSpawnManager : MonoBehaviour
{
    public GameObject[] meteorPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMeteors", 0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnMeteors()
    {
        float randomX = Random.Range(-25f, 25f);
        float randomZ = -50f;

        GameObject meteor = meteorPrefab[Random.Range(0, meteorPrefab.Length)];

        Instantiate(meteor, new Vector3(randomX, 25.46f, randomZ), meteor.transform.rotation);
    }

}
