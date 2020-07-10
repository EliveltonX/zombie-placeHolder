using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* Elivelton almeida pardini ¨¨¨ prototipo de android game survival zombie apocalipse; */

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovment : MonoBehaviour
{
    public float RadiusToGoLoot = 10f;
    public float RadiusToAtack = 10f;
    [Space(2)]
    [Header("LayersMasks")]
    public LayerMask lootMask;
    public LayerMask EnemyMask;

    [System.NonSerialized] public Vector2 movDirection;

    private NavMeshAgent navAgent;
    private Animator animator;
    private Controles controles;

    public void Awake()
    {
        controles = new Controles();

        controles.PlayerControles.MOVIMENTO.performed += ctx => movDirection = ctx.ReadValue<Vector2>().normalized;
        controles.PlayerControles.MOVIMENTO.canceled += ctx => movDirection = Vector2.zero;
        //-------
        controles.PlayerControles.INTERACT.performed += ctx => Interact();
        //-------
        controles.PlayerControles.ATACK.performed += ctx => Atack();
    }

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //Debug.Log(movDirection);

        if (movDirection != Vector2.zero)
        {
            navAgent.isStopped = true;
            navAgent.ResetPath();
            transform.rotation = Quaternion.LookRotation(new Vector3(movDirection.x, 0, movDirection.y));
            navAgent.Move(new Vector3(movDirection.x, 0, movDirection.y) * Time.deltaTime * navAgent.speed);
        }

        animator.SetFloat("Speed", myCurrentSpeed());
    }

    public void Interact()
    {
        Collider[] interactables = Physics.OverlapSphere(transform.position, RadiusToGoLoot, lootMask);
        if (interactables.Length >= 1)
        {
            navAgent.SetDestination(interactables[0].transform.position);
        }
        if (Vector3.Distance(transform.position, interactables[0].transform.position) <= navAgent.stoppingDistance) 
        {
            interactables[0].GetComponent<Interactable>().Interact();
            animator.SetTrigger("Loot");
            
        }
    }

    public void Atack() 
    {
        Collider[] atackables = Physics.OverlapSphere(transform.position, RadiusToAtack, EnemyMask);
        if (atackables.Length >= 1) 
        {
            navAgent.SetDestination(atackables[0].transform.position);
        }
        if (Vector3.Distance(transform.position, atackables[0].transform.position) <= navAgent.stoppingDistance) 
        {
            Debug.Log("Do Atack");
            animator.SetTrigger("Atack");
        }
    
    }

    Vector3 lastPos;
    private float myCurrentSpeed()
    {
        float currentSpeed = ((transform.position - lastPos) / Time.deltaTime).magnitude;
        lastPos = transform.position;
        return currentSpeed;
    }

    public void OnEnable()
    {
        controles.PlayerControles.Enable();
    }
    public void OnDisable()
    {
        controles.PlayerControles.Disable();
    }

}
