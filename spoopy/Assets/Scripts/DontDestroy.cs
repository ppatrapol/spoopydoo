using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        if (GameData.hasTransitioned)
        { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        
    }
}
