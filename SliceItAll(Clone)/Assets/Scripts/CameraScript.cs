using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.3f;
    public float height;
    public float distance;
    public float offset;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        Vector3 pos = new Vector3();
        pos.z = player.position.z + offset;
        pos.x = player.position.x - distance;
        pos.y = player.position.y + height;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);


    }
}
