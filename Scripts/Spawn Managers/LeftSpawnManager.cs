using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSpawnManager : MonoBehaviour
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
        float randomZ = Random.Range(-25f, 25f);
        float randomX = -26f;

        GameObject meteor = meteorPrefab[Random.Range(0, meteorPrefab.Length)];

        Instantiate(meteor, new Vector3(randomX, 25.46f, randomZ), meteor.transform.rotation);
    }
}
