using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{

    public string scene;
    float transitionCoolDown = 0;

   

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" && GameData.justTransition == false)
        {

            SceneManager.LoadScene(scene);
            GameData.hasTransitioned = true;
            GameData.position = other.gameObject.transform.position;
            GameData.justTransition = true;
            transitionCoolDown = 5f;
         
        }


    }



    private void OnTriggerStay(Collider other)
    {

       
    }

    private void Update()
    {
        if(transitionCoolDown > 0)
        {
            transitionCoolDown -= Time.deltaTime;
            
        }
            
        else
        {
            GameData.justTransition = false;


        }
    }
}
