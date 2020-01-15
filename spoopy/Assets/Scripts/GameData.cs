using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  GameData
{

    public static bool hasTransitioned = false;
    public static bool justTransition = false;
    public static Vector3 position;
    public static Vector3 playerDirection;

    public static bool isMenuOpen = false;
    public static string[] obtainedItemList = new string[10];
    public static int itemListIndex = 0;

}
