using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public float angle = 120f;
    public float speed = 3f;
    public float diagonal = 0.8f;
    public GameObject vision;
    public InventoryManager inventory;
    bool isInventoryOpen = false;
  
    Rigidbody rigidbody;




    void Awake()
    {

        if (GameData.hasTransitioned)
        {
      //  transform.position = GameData.position;
    
        }

    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
      
    }


    void Update()
    {
        if (!GameData.isMenuOpen)
        {
            PlayerMovement();

        }
       
        SpritePerspective();

        if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen == false)
        {
            inventory.DisplayInventory();
            isInventoryOpen = true;
            GameData.isMenuOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen == true)
        {
            inventory.CloseInventory();
            isInventoryOpen = false;
            GameData.isMenuOpen = false;
        }

    }


    void SpritePerspective()
    {
        Quaternion rotating;

        rotating = Quaternion.identity;
        rotating.w = angle;


        rotating.x = mainCamera.transform.position.y;
        vision.transform.rotation = rotating;

    }



    void PlayerMovement()
    {
        Vector3 position;
        Vector3 direction = new Vector3(0f,0f,1f);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Ray ray = new Ray();



        position = rigidbody.position;


        if(!Mathf.Approximately(horizontal,0f) || !Mathf.Approximately(vertical, 0f))
        { 

        direction.Set(horizontal, 0f, vertical);
        direction.Normalize();
           
        vision.transform.position = direction/2 + position;
        
        }



        if (vertical != 0 && horizontal !=0)
        {

            vertical *= diagonal;
            horizontal *= diagonal;

        }

        ray.origin = position;
        ray.direction = direction;

    

        position.z = position.z + vertical * speed * Time.deltaTime;
        position.x = position.x + horizontal * speed * Time.deltaTime;

        GameData.position = position;
        rigidbody.MovePosition(position);
    }





}
