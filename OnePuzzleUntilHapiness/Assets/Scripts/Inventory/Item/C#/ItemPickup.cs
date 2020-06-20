using UnityEngine;

public class ItemPickup : Interactable
{
    public override void Interact()
    {

        Pickup();
        
    }


    private void Pickup() 
    {

        Debug.Log("Voce pegou um(a) :" + whatItemIs.itemName);
        if (Inventory.instance.Add(whatItemIs)) 
        {
            Destroy(gameObject);
        }
        
    
    }
}
