using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    bool interactibleIsInRange = false;
    public PlayerController player;
    Vector3 interactiblePosition;
    RaycastHit raycastHit;
   // public Canvas dialogueBox;
    public InventoryManager inventory;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "NPC")
        {
            interactibleIsInRange=true;
            interactiblePosition = other.gameObject.transform.position;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "NPC")
        {
            interactibleIsInRange = false;
        }
    }


    private void Update()
    {
        
        
            Vector3 interactible;
            Vector3 playerView;

     //   if (!GameData.isMenuOpen)
      //  {
            if (interactibleIsInRange)
            {
                playerView = player.transform.position;
                interactible = interactiblePosition - playerView;
                ObjectInteraction(playerView, interactible);

            }
       // }
    }



    void ObjectInteraction(Vector3 origin, Vector3 direction)
    {
      

        if (Physics.Raycast(origin, direction, out raycastHit))
        {


            if (raycastHit.collider.transform.tag == "Item")
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                   
                    Item item = raycastHit.collider.gameObject.GetComponent<Item>();
                    Debug.Log(item.name);
                    inventory.AddItem(item);

                    
                    Debug.Log("Item Get");
                    interactibleIsInRange = false;
                    Destroy(raycastHit.collider.gameObject);
                }

                
            }

            else if (raycastHit.collider.transform.tag == "NPC")
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    NPCController npc;
                    Debug.Log("NPC Spotted");
                    npc = raycastHit.collider.gameObject.GetComponent<NPCController>();
                    npc.Talk(inventory);
                }


            }




        }



    }
}
