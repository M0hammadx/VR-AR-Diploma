using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{

    float xPos, yPos;
    public float speed = 1;
    // Use this for initialization
    void Start()
    {
     //   Debug.Log(transform.eulerAngles);
        xPos = transform.eulerAngles.x;
        yPos = transform.eulerAngles.y;

      //  Debug.Log(xPos);
        //Debug.Log(yPos);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yPos += Input.GetAxis("Horizontal");
        xPos -= Input.GetAxis("Vertical");

       // Debug.Log(xPos);
      //  Debug.Log(yPos);
        // transform.position += new Vector3(-xPos, -yPos, 0) * speed;
        transform.rotation = Quaternion.Euler(xPos, yPos, 0);   
        
    }
}
