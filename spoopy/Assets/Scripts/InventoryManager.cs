using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    Item[] items;
    public int inventorySpace;
    public TextMeshProUGUI[] displayItems;
    public TextMeshProUGUI[] displayItemsAmount;
    int slot = 0;
    public Canvas inventoryUI;
    public Image cursor;
    bool isInventoryEmpty = true;
    int currentCursorPosition = 0;
    int inventoryOffset = 0;
    Vector3 initialCursorPosition;

    public void Start()
    {
        items = new Item[inventorySpace];
        initialCursorPosition = cursor.rectTransform.localPosition;
    }

    public void AddItem(Item item)
    {

        int counter = 0;
        bool hasDuplicate = false;

        GameData.obtainedItemList[GameData.itemListIndex] = item.itemID;       
        GameData.itemListIndex++;

        while (counter < slot)
        {


            if (items[counter].name == item.name)
            {
                hasDuplicate = true;
                items[counter].amount += item.amount;
                Debug.Log("Current item amount " + items[counter].amount);
                break;

            }


            counter++;

        }

        if (!hasDuplicate)
        {
            items[slot] = item;
            slot++;


        }

      

    }

    public void UseItem(Item item)
    {



    }


    public void MoveCursor()
    {
        Vector3 moveCursor = new Vector3(0, 30, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {

            currentCursorPosition--;
            if (currentCursorPosition < 0)
            {
                currentCursorPosition++;
                if (inventoryOffset > 0)
                {
                    inventoryOffset--;
                }
            }
            else
                cursor.rectTransform.localPosition += moveCursor;

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {

            if (currentCursorPosition < slot - 1)
            {

                currentCursorPosition++;
                if (currentCursorPosition >= displayItems.Length)
                {
                    currentCursorPosition--;
                    if (displayItems.Length + inventoryOffset < slot)
                        inventoryOffset++;


                }
                else
                    cursor.rectTransform.localPosition -= moveCursor;


            }
        }

    }

    public void DisplayInventory()
    {

        int counter = 0;
        Debug.Log(inventoryOffset);
        inventoryUI.gameObject.SetActive(true);

        while (counter < slot)
        {

            if (counter < displayItems.Length)
            {

                if (items[counter].name != null)
                {

                    displayItems[counter].text = items[counter + inventoryOffset].name;
                    displayItemsAmount[counter].text = "x" + items[counter + inventoryOffset].amount.ToString();


                }

                else
                {

                    break;

                }

            }

            else
            {

                break;
            }

            counter++;

        }

    }

    private void Update()
    {
        if(inventoryUI.isActiveAndEnabled)
        {
            DisplayInventory();
            Debug.Log(cursor.rectTransform.localPosition);
            MoveCursor();
        }
    }

    public void CloseInventory()
    {

        inventoryUI.gameObject.SetActive(false);
        inventoryOffset = 0;
        currentCursorPosition = 0;
        cursor.rectTransform.localPosition = initialCursorPosition;
    }


    public bool CheckInventory(string itemName)
    {
        bool itemIsInInventory = false;
        int counter = 0;

        while(counter < slot)
        {
           
            
         if(items[counter].name == itemName)
         {
               
                itemIsInInventory = true;
                break;
         }

            counter++;
        }
      
        return itemIsInInventory;
    }

    public bool CheckInventory(string itemName, int amount)
    {
        bool hasRequiredAmount = false;
        int counter = 0;

        while (counter < slot)
        {


            if (items[counter].name == itemName)
            {
                if(items[counter].amount >= amount)
                {
                    hasRequiredAmount = true;
                    break;

                }
               
              
            }

            counter++;
        }

        return hasRequiredAmount;
    }

}
