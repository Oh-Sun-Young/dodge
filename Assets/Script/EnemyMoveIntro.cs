using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveIntro : MonoBehaviour
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
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            timer = 0;
            maxTimer = Random.Range(1, 3);
            target = transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        }
        if (nav.isOnNavMesh)
        {
            if (Vector3.Distance(transform.position, prevPos) < 0.025f)
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
