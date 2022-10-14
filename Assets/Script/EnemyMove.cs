using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    float timer;
    float maxTimer;
    NavMeshAgent nav;
    Animator enemyAnimator;
    Vector3 target;
    public Vector3 prevPos;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Data.isGame) nav.enabled = true;
        else nav.enabled = false;
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer = 0;
            maxTimer = Random.Range(1, 10);
            target = new Vector3(Random.Range(-7, 7), 0, Random.Range(-6, 6));
        }
        if (nav.isOnNavMesh)
        {
            if(Vector3.Distance(transform.position, prevPos) < 0.01f)
            {
                enemyAnimator.SetBool("isMove", false);
            }
            else
            {
                enemyAnimator.SetBool("isMove", true);
            }
            nav.destination = target;
            prevPos = transform.position;
        }
        
    }
}
