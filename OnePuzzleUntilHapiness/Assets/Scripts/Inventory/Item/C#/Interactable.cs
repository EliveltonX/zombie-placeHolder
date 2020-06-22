using UnityEngine;

public class Interactable : MonoBehaviour
{
    //public ones;
    public float radiusToInteract = 3;
    public Transform interactTransform;
    public Item whatItemIs = null;

    //private ones;
    private bool imTheFocus = false;
    private Transform playerTr;
    private bool hasInteracted = false;


    public void Update()
    {

        CheckForInteraction();
    }

    public virtual void CheckForInteraction() 
    {
        if (imTheFocus && !hasInteracted)
        {

            if (Vector3.Distance(interactTransform.position, playerTr.position) <= radiusToInteract)
            {
                Interact();

            }

        }
    }

    public virtual void Interact() 
    {
        // this method need to be overwriten;
        Debug.Log("Interacting");
        hasInteracted = true;
    }


    public void SetFocus(Transform _playerTr) 
    {
        imTheFocus = true;
        playerTr = _playerTr;
        //Debug.Log("Ido");
    }

    public void ClearFocus() 
    {
        imTheFocus = false;
        playerTr = null;
        hasInteracted = false;
    }

    public void OnDrawGizmosSelected()
    {
        if (interactTransform == null)
        {
            interactTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactTransform.position, radiusToInteract);
    }

}
