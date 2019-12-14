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
    Rigidbody rigidbody;


    void Awake()
    {
        if (!GameData.hasTransitioned)
        GameData.position.Set(0f, 0.7f, -4.5f);

       
       

    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerMovement();
        SpritePerspective();


    }


    void SpritePerspective()
    {
        Quaternion rotating;

        rotating = Quaternion.identity;
        rotating.w = angle;


        rotating.x = mainCamera.transform.position.y;
        transform.rotation = rotating;

    }

    void PlayerMovement()
    {
        Vector3 position;
        Vector3 direction = new Vector3(0f,0f,1f);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        position = rigidbody.position;


        if(!Mathf.Approximately(horizontal,0f) || !Mathf.Approximately(vertical, 0f))
        { 

        direction.Set(horizontal, 0f, vertical);

        direction.Normalize();
           
  
        vision.transform.position = direction + position;
        }



        if (vertical != 0 && horizontal !=0)
        {

            vertical *= diagonal;
            horizontal *= diagonal;

        }


        position.z = position.z + vertical * speed * Time.deltaTime;
        position.x = position.x + horizontal * speed * Time.deltaTime;

        GameData.position = position;
        rigidbody.MovePosition(position);
    }

    
}
