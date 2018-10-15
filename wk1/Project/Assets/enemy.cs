using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float speed = 5;
    public int HP = 1;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10);
        transform.LookAt(Camera.main.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Camera.main.transform.position - transform.position).normalized * speed * Time.deltaTime;
        if ((Camera.main.transform.position - transform.position).magnitude < 2)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            HP--;
            if (HP == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
