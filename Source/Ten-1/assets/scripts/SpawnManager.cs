using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        repeatRate = Random.Range(1.0f, 3.0f);
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
