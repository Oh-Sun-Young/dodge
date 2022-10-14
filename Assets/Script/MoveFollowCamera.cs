using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFollowCamera : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = Quaternion.LookRotation(player.transform.forward * -1);
        transform.Translate(Vector3.forward * -2 + Vector3.up * 1.93f);
    }
}
