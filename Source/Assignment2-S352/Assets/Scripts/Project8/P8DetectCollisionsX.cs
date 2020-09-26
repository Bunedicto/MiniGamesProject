using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P8DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
