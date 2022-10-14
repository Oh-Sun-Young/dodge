using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    public bool[] bPrefabType;
    public Transform[] posPrefab;
    public bool[] bPrefabPos;
    public int cntPrefab;

    public void SpawnEnemy()
    {
        int i;
        for (i = 0; i < bPrefabPos.Length; i++)
        {
            bPrefabPos[i] = false;
        }
        for (i = 0; i < bPrefabType.Length; i++)
        {
            bPrefabType[i] = false;
        }
        for (cntPrefab = 0; cntPrefab < Data.stage; cntPrefab++)
        {
            int numPrefabType = Random.Range(0, prefab.Length);
            int numPrefabPos = Random.Range(0, posPrefab.Length);
            if (!bPrefabType[numPrefabType] && !bPrefabPos[numPrefabPos])
            {
                Instantiate(prefab[numPrefabType], posPrefab[numPrefabPos]);
                cntPrefab++;
            }
            cntPrefab--;
            if (numPrefabType == 2 || numPrefabType == 3) bPrefabType[numPrefabType] = true;
            bPrefabPos[numPrefabPos] = true;
        }
    }
}
