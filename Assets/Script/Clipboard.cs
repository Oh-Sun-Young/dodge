using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour
{
    public int color;
    public float speed;
    private float speedRotate = 3f;
    bool check;

    void Start()
    {
        speed = 5f;
        check = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player")
        {
            if (check)
            {
                if (Data.mission == color)
                {
                    Data.cntMission += 1;
                }
                else if (Data.mission != color)
                {
                    Data.time -= 10;
                }
                Destroy(gameObject, 0f);
                check = false;
            }
        }
    }

    void Update()
    {
        if (Data.isGame)
        {
            transform.Translate(transform.forward * -1 * speed * Time.deltaTime);
            transform.Find("ClipboardInner").transform.Rotate(speedRotate, speedRotate, speedRotate);
        }
        if (Data.isResult == true) Destroy(gameObject, 0);
    }
}
