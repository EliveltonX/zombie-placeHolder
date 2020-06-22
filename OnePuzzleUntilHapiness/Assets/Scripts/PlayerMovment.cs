using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]

public class PlayerMovment : MonoBehaviour
{
    public Transform cameraTrans;              
    public float cameraSpeed = 1;               // the smooth factor of Camera Following the player;
    public float playerVelocity = 1f;           //velocity of player movment;
    public float findLootRadius = 5;            //the distance for find loot;
    public LayerMask loots;                     // layer mask for loots used in overlapSpher;

    public Transform graphycsPlayer;            //the mesh of player to rotate towards mov direction;
    public float findEnemyRadius = 10f;         //distance I can find Enemies;
    public LayerMask enemiesLayer;              //layermask for enemies;


    private InventoryUI inventoryUI;
    private Vector2 moveDir;                    // the input to say direction player needs to move;
    private Vector3 cameraOffset;               // the camera offset is set on Start method
    private Rigidbody rb;
    private NavMeshAgent navMesh;
    private Vector3 ref_camVelocity;            // the current velocity of the camera on smoothDamp;
    private Interactable myFocus;               //what im focusing;
    //private Atackable myTarget = null;
    private Animator anim;                      // animartor from child player mesh;
    private float currentSpeed = 0f;            //the current speed by Calculatint by calculateMySpeed();
    private bool iHaveDestination;              // true if player focusing anithyng;

    GameControls controlls;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();     
        navMesh = GetComponent<NavMeshAgent>();
        cameraOffset =  cameraTrans.position - transform.position;
        inventoryUI = FindObjectOfType<InventoryUI>();
        anim = GetComponentInChildren<Animator>();

        controlls = new GameControls();
        controlls.Game.Interaction.performed += ctx => FindLoot();
        controlls.Game.Atack.performed += ctx => Atack();
        controlls.Game.Inventory.performed += ctx => inventoryUI.inventoryOnOff();
        controlls.Game.Walk.performed += ctx => moveDir = ctx.ReadValue<Vector2>();
        controlls.Game.Walk.canceled += ctx => moveDir = Vector2.zero;
    }

    private void Update()
    {

        //Debug.Log("Target = " + myTarget + "\n Focus = " + myFocus);

        if (inventoryUI.inventoryScreen.activeSelf) { return; }

        #region Camera Controller; // here i made the camera smoothDamp;

        cameraTrans.position = Vector3.SmoothDamp(cameraTrans.position, transform.position + cameraOffset, ref ref_camVelocity, cameraSpeed);

        #endregion 

        if (moveDir != Vector2.zero)   // when player use the sticks stop following interactables and go to direction of stick;
        {
            if (myFocus != null)
            {
                myFocus.ClearFocus();
                myFocus = null;

            }

            Vector3 movimento = new Vector3(moveDir.x, rb.velocity.y, moveDir.y) * Time.deltaTime * playerVelocity;
            transform.rotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.y));
            navMesh.ResetPath();
            navMesh.Move(movimento);

            //Debug.Log(moveDir);
        }
        else 
        {
            Debug.Log("My Focus = " + myFocus);

            if (myFocus != null) 
            {
                navMesh.SetDestination(myFocus.transform.position);
            }
            FaceTarget();
        }



        anim.SetFloat("PlayerVelocity", currentSpeed); 
        calculateMySpeed();// tirar isso do Update Quebra as Animaçoes!!!

    }

    private void Atack() 
    {
        if (inventoryUI.inventoryScreen.activeSelf) { return; }

        //Debug.Log("I press Atack");
        Collider[] myTargets = Physics.OverlapSphere(transform.position, findEnemyRadius, enemiesLayer);

        if (myTargets.Length > 0)
        {
            Interactable newTarget = myTargets[0].GetComponent<Atackable>();
            if (myFocus != newTarget)
            {
                if (myFocus != null)
                {
                    myFocus = null;
                }
                myFocus = newTarget;
                navMesh.SetDestination(myFocus.transform.position);
            }
            else 
            {
                Debug.Log("Do Atack");
            }


            //Debug.Log("Im atacking :" + myTargets[0].name);
        }
        else 
        { 
            //Debug.Log("Nenhun inimigo encontrado"); 
        }
    }

    private void FindLoot() // player seek for loots on Radius and go for then;
    {
        if (inventoryUI.inventoryScreen.activeSelf) { return; }

        Collider[] myLoots = Physics.OverlapSphere(transform.position, findLootRadius, loots);

        if (myLoots.Length > 0)
        {
            Interactable newFocus = myLoots[0].GetComponent<Interactable>();

            if ( myFocus != newFocus)
            {
                if (myFocus != null) 
                {
                    myFocus.ClearFocus();
                }

                myFocus = newFocus;
                myFocus.SetFocus(transform);
                navMesh.SetDestination(myFocus.transform.position);
            }
        }
        else 
        {
            Debug.Log("Nenhum loot encontrado");
            
        }

    }

    private void OnDrawGizmosSelected()
    {   
        //Interactables
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, findLootRadius);
        //Enemies
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, findEnemyRadius);
    }


    private Vector3 lastPos;
    private void calculateMySpeed() 
    {
        currentSpeed = ((transform.position - lastPos)/Time.deltaTime).magnitude;
        lastPos = transform.position;
    }

    void FaceTarget()
    {
        

        float distance = Vector3.Distance(navMesh.destination , transform.position);

        if (distance <= navMesh.stoppingDistance && distance >0)
        {
            Vector3 direction = (navMesh.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        //Debug.Log("Distance" + distance);
    }

    private void OnEnable()
    {
        controlls.Game.Enable();
    }
    private void OnDisable()
    {
        controlls.Game.Disable();
    }
}
