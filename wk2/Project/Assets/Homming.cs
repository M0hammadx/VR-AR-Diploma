using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homming : MonoBehaviour
{

    public float speed = 3;
    GameObject[] enemies;
    Vector3 dir;
    GameObject target;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float min = Mathf.Infinity;
        foreach (var item in enemies)
        {
            dir = item.transform.position - transform.position;
            if (min > dir.magnitude)
            {
                target = item;
                min = dir.magnitude;
            }


        }
    }

    private void Update()
    {
        if (!target) Destroy(gameObject);
        //if (!target && enemies.Length > 0) Destroy(gameObject);
        dir = target.transform.position - transform.position;
        transform.LookAt(target.transform);
        rb.velocity = dir * speed * Time.deltaTime;
    }



}
