using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 camOffset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset camera to view player correctly
        transform.position = player.transform.position + camOffset;
    }
}
