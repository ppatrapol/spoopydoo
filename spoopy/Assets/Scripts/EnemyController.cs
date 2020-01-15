using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Rigidbody rigidbody;

    public float sightLength; 
    public float movementSpeed;
    public GameObject sight;
  //  public GameObject vision;
    public Transform[] waypoints;
    bool isReturning = false;
    int waypointIndex;
    int routeLoop = 1;
    float chaseTimer = 2f;

    public bool playerDetected { get { return isPlayerDetected; } set { isPlayerDetected = value; } }
    bool isPlayerDetected = false;
    bool isDirectionStored;

    Vector3 enemyVision = new Vector3();

    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody>();
        
    }

  
    void Update()
    {
        if (!GameData.isMenuOpen)
        {
            Movement();
        }

    }



    void Movement()
    {
        Vector3 position;
        Vector3 newPosition;
        Vector3 direction;
        Vector3 remainingDistance;
     
        
        Ray ray = new Ray();
      
        RaycastHit raycastHit;
     


        position = rigidbody.position;
        newPosition = position;   


        if (isPlayerDetected == false )
        {
        
            direction = waypoints[waypointIndex].position - position;
            if(isReturning)
            {
                isDirectionStored = false;
                isReturning = false;
            }
           
            
        }
        /*
        else if (isPlayerDetected == false && isReturning == false)
        {

            direction = waypoints[waypointIndex].position - position;
     

        }
        */
        else
        {
            direction = GameData.position - position;
            isDirectionStored = false;

        }


        remainingDistance.x = System.Math.Abs(direction.x);
        remainingDistance.z = System.Math.Abs(direction.z);


        direction.Normalize();
        direction.y = 0f;
    


        if (!isDirectionStored)
        {
           
            enemyVision = direction;
            isDirectionStored = true;
  
        }

        newPosition = newPosition + direction * movementSpeed * Time.deltaTime;

       

        ray.origin = position;   
        ray.direction = enemyVision ;
       
        sight.transform.position = position + enemyVision * sightLength;


        

        //****************** ENEMY VISION *************************

        if (Physics.Raycast(ray, out raycastHit, sightLength))
        {
          

            if (raycastHit.collider.gameObject.tag == "Player" && isPlayerDetected == false)
            {
                Debug.Log("It works");
                isPlayerDetected = true;
                chaseTimer = 2f;


            }

            
            else if (raycastHit.collider.gameObject.tag != "Player")
            {
                chaseTimer -= Time.deltaTime;

                if (chaseTimer <= 0 && isPlayerDetected == true)
                {
                     isPlayerDetected = false;
                     isReturning = true;

                }


            }
             
        }

      


        //********************************************************




        rigidbody.MovePosition(newPosition);





        //****************** WAYPOINTS ****************************


        if (remainingDistance.x <= 0.15f && remainingDistance.z <= 0.15f)
        {


            if (waypointIndex + 1 >= waypoints.Length && routeLoop == 1)
            {

                routeLoop *= -1;
                
            }

            else if (waypointIndex - 1 < 0 && routeLoop == -1)
            {

                routeLoop *= -1;

            }

            waypointIndex += routeLoop;

            isDirectionStored = false;
            isReturning = false;

        }

      
        //***********************************************************
      

    }
}
