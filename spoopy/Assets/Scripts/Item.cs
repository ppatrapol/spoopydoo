using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public int amount = 1;
    public string itemID;

    private void Awake()
    {
        int counter = 0;

        while (counter < GameData.itemListIndex)
        {
            if(GameData.obtainedItemList[counter] == itemID)
            {
                Destroy(gameObject);

            }

            counter++;
        }


    }
}
