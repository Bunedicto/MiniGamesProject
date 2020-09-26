using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P13EnemyX : MonoBehaviour
{
    public float speed = 10.0f;
    public float speedMultiplier = 1.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    private P13SpawnManagerX spawnScript;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        spawnScript = GameObject.Find("Spawn").GetComponent<P13SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime * speedMultiplier);


        speedMultiplier = spawnScript.waveCount;
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
        
    }

}
