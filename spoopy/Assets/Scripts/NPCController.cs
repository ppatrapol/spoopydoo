using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCController : MonoBehaviour
{
    
    public bool isDialogueLooping;


    [TextArea(3, 5)]
    public string[] dialogues;
    public int dialoguePause;
    public string[] conditionalDialogue;
    public string[] questItem;
    public int[] questItemAmount;
    int questItemSlot = 0;
    bool hasQuestItem = false;
    int dialogueInt;
    DialogueBox dialogueBox;



    private void Start()
    {
        dialogueBox = GetComponent<DialogueBox>();
   
    }


    public void Talk(InventoryManager inventory)
    {

       
        if (questItem.Length > 0)
        { 

           if (inventory.CheckInventory(questItem[questItemSlot] , questItemAmount[questItemSlot]))
          {
              if(!hasQuestItem)
              dialogueInt = dialoguePause;

              dialoguePause = dialogues.Length;
              hasQuestItem = true;

          }

        }

        if (dialogueInt < dialoguePause)
        {
            dialogueBox.textBox.gameObject.SetActive(true);
            GameData.isMenuOpen = true;
            dialogueBox.TextSet(dialogues[dialogueInt]);
            dialogueInt++;
            


        }

        
        else if (dialogueInt >= dialoguePause)
        {

            if (!isDialogueLooping)
            {
                dialogueInt -= 1;
            }
            else
            {
                dialogueInt = 0;
            }
           
            dialogueBox.textBox.gameObject.SetActive(false);
            GameData.isMenuOpen = false;
        }


    }

    
}
