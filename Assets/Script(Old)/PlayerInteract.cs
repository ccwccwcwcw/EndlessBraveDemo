using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    

    private void Update() {
        //if (OVRInput.Get(OVRInput.Button.Two)) {
        if (Input.GetKeyDown(KeyCode.E)) { 
            float interactRange = 2f;
           Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
           foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)) {
                    npcInteractable.Interact();
                }
                
            }
        }
    }

    public NPCInteractable GetInteractable()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                return npcInteractable;
            }

        }
        return null;
    }
}
