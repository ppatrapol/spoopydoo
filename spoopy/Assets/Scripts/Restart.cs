using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            SceneManager.LoadScene(1);
            GameData.hasTransitioned = true;
            other.gameObject.transform.position = GameData.position;
        }


    }
}
