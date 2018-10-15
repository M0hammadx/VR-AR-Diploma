using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMove : MonoBehaviour
{

    // Use this for initialization
    Vector3 mov;
    public float speed = 0.2f;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mov);
        mov = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * speed * Time.deltaTime;
        transform.position += (mov);

        if (mov.x != 0 && mov.z != 0)
            transform.rotation = Quaternion.Euler(0, 180 + Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg, 0);
    }
}
