using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    bool isPlayerInRange = false;
    public EnemyController enemy;
    Vector3 playerPosition;
    RaycastHit raycastHit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
            playerPosition = other.gameObject.transform.position;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
            enemy.playerDetected = false;
        }
    }


    private void Update()
    {


        Vector3 interactiblePosition;
        Vector3 enemyView;

        if (isPlayerInRange)
        {
            enemyView = enemy.transform.position;
            interactiblePosition = playerPosition - enemyView;



            EnemyChase(enemyView, interactiblePosition);
         
        }

    }



    void EnemyChase(Vector3 origin, Vector3 direction)
    {
        


        if (Physics.Raycast(origin, direction, out raycastHit))
        {


            Debug.Log(raycastHit.collider.gameObject.tag);
            if (raycastHit.collider.transform.tag == "Player")
            {

                enemy.playerDetected = true;


            }

        }
    }
}
