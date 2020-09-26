using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P10MoveLeft : MonoBehaviour
{
    private float speed = 30.0f;
    private float leftBound = -15.0f;
    private P10PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<P10PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
