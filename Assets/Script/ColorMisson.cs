using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorMisson : MonoBehaviour
{
    public int color;
    void Update()
    {
        if (Data.mission == color) GetComponent<RawImage>().enabled = true;
        else GetComponent<RawImage>().enabled = false;
    }
}