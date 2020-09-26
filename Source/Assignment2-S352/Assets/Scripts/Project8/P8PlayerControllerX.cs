using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P8PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool wait = false;
    public float interval = 1.0f;
    public float latency = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > latency)
        {
            latency = Time.time + interval;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
