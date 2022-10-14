using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabDestroy : MonoBehaviour
{
    void Update()
    {
        if(!Data.isGame && Data.isResult) Destroy(gameObject, 0);
    }
}
