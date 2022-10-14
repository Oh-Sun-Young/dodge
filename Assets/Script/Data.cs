using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Data : MonoBehaviour
{
    public static int stage;
    public string[] stageName;
    public static bool isGame; // 게임 진행 여부 확인
    public static bool isResult; // 게임 결과 여부 확인

    public static float time;
    public static int mission;
    public int tempMission;
    public static int cntMission;
    public static int maxMission;

    public static Vector3 posPlayer;

    public GameObject popupMission;
    public GameObject popupSuccess;
    public GameObject popupFail;
    public GameObject popupPause;
    public GameObject popupEndding;

    public GameObject btnHud;
    public GameObject emptyBtnHud;

    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textMission;
    public TextMeshProUGUI numMission;
    public TextMeshProUGUI textPosition;
    public TextMeshProUGUI textSuccess;


    public AudioClip clipTimer;
    public bool isSound;

    // Start is called before the first frame update
    void Start()
    {
        stage = -1;
        posPlayer = GameObject.Find("Player").transform.position;
        isSound = true;
        GameSet(true);
    }
    public static void GameSet(bool reset)
    {
        if (reset)
        {
            Data.stage = 0;
            Data .isResult = true;
        }
        else
        {
            Data.stage++;
            Data.isResult = false;
        }
        Data.isGame = false;
        time = 60;
        mission = Random.Range(0, FindObjectOfType<ClipboardSpawner>().GetComponent<ClipboardSpawner>().clipboardPrefab.Length);
        cntMission = 0;
        maxMission = stage + 1;
        GameObject.Find("Player").transform.position = posPlayer;
        GameObject.Find("Player").transform.rotation = Quaternion.LookRotation(Vector3.zero);
        FindObjectOfType<Data>().GetComponent<Data>().numMission.text = (maxMission < 10 ? "0" : "") + maxMission;
        FindObjectOfType<Data>().GetComponent<Data>().popupMission.SetActive(true);
        FindObjectOfType<Data>().GetComponent<Data>().popupSuccess.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupFail.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupPause.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupEndding.SetActive(false);
    }
    public static void GameStart()
    {
        Data.isGame = true;
        Data.isResult = false;
        FindObjectOfType<Data>().GetComponent<Data>().isSound = true;
        FindObjectOfType<Data>().GetComponent<Data>().popupMission.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupSuccess.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupFail.SetActive(false);
        FindObjectOfType<Data>().GetComponent<Data>().popupEndding.SetActive(false);
        FindObjectOfType<Spawn>().GetComponent<Spawn>().SpawnEnemy();
    }
    public static void GamePause()
    {
        Data.isGame = false;
        FindObjectOfType<Data>().GetComponent<Data>().popupPause.SetActive(true);
    }
    public static void GamePlay()
    {
        Data.isGame = true;
        Data.isResult = false;
        FindObjectOfType<Data>().GetComponent<Data>().isSound = true;
        FindObjectOfType<Data>().GetComponent<Data>().popupPause.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        tempMission = mission;
        if (isGame)
        {
            float m;
            float s;
            if (time > 0)
            {
                if (isGame) time -= Time.deltaTime;
                m = time / 60;
                s = time % 60;
            }
            else
            {
                if (cntMission < maxMission)
                {
                    isResult = true;
                    popupFail.SetActive(true);
                }
                m = 0;
                s = 0;
                isGame = false;
            }
            if (cntMission >= maxMission)
            {
                isGame = false;
                isResult = true;
                cntMission = maxMission;
                textSuccess.text = "축하드립니다!<br>'<b>" + stageName[stage + 1] + "</b>'(으)로 승진되었습니다.";
                if (stage < stageName.Length)
                {
                    popupSuccess.SetActive(true);
                }
                else
                {
                    popupEndding.SetActive(true);
                }
            }
            if (time > 0) textTime.text = (m < 10 ? "0" : "") + (int)m + ":" + (s < 10 ? "0" : "") + (int)s;
            textMission.text = (cntMission < 10 ? "0" : "") + cntMission + "/" + (maxMission < 10 ? "0" : "") + maxMission;
            textPosition.text = stageName[stage];
            if (time < 9 && isSound)
            {
                isSound = false;
                GetComponent<AudioSource>().PlayOneShot(clipTimer);
            }
        }
        if (!isGame)
        {
            GetComponent<AudioSource>().Pause();
            btnHud.SetActive(false);
            emptyBtnHud.SetActive(true);
        }
        else
        {
            btnHud.SetActive(true);
            emptyBtnHud.SetActive(false);
        }
    }
}
