using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    public float speed = 0.0001f;
    public float xBtn;
    public float zBtn;

    public AudioClip clipWow;
    public AudioClip clipSurptise;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clipboard")
        {
            GetComponent<AudioSource>().Pause();
            if (Data.mission == other.gameObject.GetComponent<Clipboard>().color)
            {
                GetComponent<AudioSource>().PlayOneShot(clipWow);
            }
            else if (Data.mission != other.gameObject.GetComponent<Clipboard>().color)
            {
                GetComponent<AudioSource>().PlayOneShot(clipSurptise);
            }
        }
    }

    void Update()
    {
        if (Data.isGame)
        {
            float xInput = Input.GetAxis("Horizontal");
            float zInput = Input.GetAxis("Vertical");

            float xSpeed = xInput * speed + xBtn * speed;
            float zSpeed = zInput * speed + zBtn * speed;

            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
            if (xInput != 0 || zInput != 0 || xBtn != 0 || zBtn != 0)
            {
                gameObject.transform.rotation = Quaternion.LookRotation(newVelocity);
                playerAnimator.SetBool("isMove", true);
            }
            else
            {
                playerAnimator.SetBool("isMove", false);
            }
            playerRigidbody.velocity = newVelocity;
        }
        else
        {
            playerAnimator.SetBool("isMove", false);
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
