using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowplayer : MonoBehaviour
{
    public float offset = 3f;
    private GameObject player;
    private Vector3 position;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = 0f;
        position.y =5f;
        position.z = player.transform.position.z - offset;
        transform.SetPositionAndRotation(position, rotation);
    }
}
