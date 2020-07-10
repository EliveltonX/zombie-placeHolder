using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBase : MonoBehaviour
{
    public float detectRadius = 5f;
    public float atackInterval = 1f;
    public LayerMask playerMask;

    private NavMeshAgent navAgent;
    private Animator anim;
    private float timer = 0f;

    public void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        Collider[] players = Physics.OverlapSphere(transform.position, detectRadius, playerMask);
        if (players.Length >= 1)
        {

            navAgent.SetDestination(players[0].transform.position);
            

            if (Vector3.Distance(transform.position, players[0].transform.position) <= navAgent.stoppingDistance)
            {
                if (timer <= 0) 
                {
                    Atack();
                    timer = atackInterval;
                }
            }

        }
        timer -= Time.deltaTime;
        anim.SetFloat("Speed", myCurrentSpeed());
    }

    Vector3 lastPos;
    private float myCurrentSpeed()
    {
        float currentSpeed = ((transform.position - lastPos) / Time.deltaTime).magnitude;
        lastPos = transform.position;
        return currentSpeed;
    }
    public virtual void Atack() 
    {
        //Debug.Log("Zombie Atack");
        anim.SetTrigger("Atack");
    }
}
