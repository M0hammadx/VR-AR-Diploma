using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public float offset = 5, speed = 3;
    public GameObject throwable;
    bool canFire = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canFire && Input.GetAxis("Fire1") > 0)
        {

            Instantiate(throwable, transform.position + transform.forward * offset, transform.rotation).GetComponent<Rigidbody>().velocity = transform.forward * speed;
            canFire = false;
        }
        else if (!canFire && Input.GetAxis("Fire1") <= 0)
        {
            canFire = true;
        }
    }
}
