using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public void Update()
    {
       
    }

    public virtual void Interact() 
    {
        Debug.Log("This is " + transform.name);
    }

}
