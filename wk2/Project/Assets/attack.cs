using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public float offset = 5, speed = 3;
    public GameObject throwable, homming;
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
            if (GameManager.GM.weoponType == true)
            {
                Instantiate(throwable, transform.position + transform.forward * offset, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
            }
            else
            {
                if (GameManager.GM.canHome)
                {
                    GameManager.GM.canHome = false;
                    Instantiate(homming, transform.position + transform.forward * offset, transform.rotation).GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);
                }
            }
            canFire = false;
        }
        else if (!canFire && Input.GetAxis("Fire1") <= 0)
        {
            canFire = true;
        }

    }
}
