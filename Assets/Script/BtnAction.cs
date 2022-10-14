using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnAction : MonoBehaviour
{
    public string arrowMove;
    public int numScene;
    public AudioClip clipClick;

    public void LoadGame()
    {
        Data.GameStart();
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void SetGame()
    {
        Data.GameSet(false);
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void ResetGame()
    {
        Data.GameSet(true);
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void PauseGame()
    {
        Data.GamePause();
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void PlayGame()
    {
        Data.GamePlay();
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void QuitGame()
    {
        Application.Quit();
        GameObject.Find("PopupHud").GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void ButtonUp()
    {
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().xBtn = 0;
        FindObjectOfType<PlayerController>().GetComponent<PlayerController>().zBtn = 0;
    }
    public void ButtonDown()
    {
        if(arrowMove == "t")
        {
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().zBtn = 1;
        }
        else if (arrowMove == "b")
        {
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().zBtn = -1;
        }
        else if (arrowMove == "l")
        {
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().xBtn = -1;
        }
        else if (arrowMove == "r")
        {
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().xBtn = 1;
        }
        GetComponent<AudioSource>().PlayOneShot(clipClick);
    }
    public void SceneMove()
    {
        SceneManager.LoadScene(numScene);
    }
}
