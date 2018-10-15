using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public float spawnTimer = 3;
    public Transform center, left, right;
    public GameObject enemy, enemy2;
    float currTime = 0;
    int rand;
    GameObject currSpawn;
    Vector3 currPos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= spawnTimer)
        {
            currTime = 0;
            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                currSpawn = Instantiate(enemy);
            }
            else
            {
                currSpawn = Instantiate(enemy2);
            }

            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                currPos = new Vector3(Random.Range(center.position.x, left.position.x), Random.Range(center.position.y, left.position.y), Random.Range(center.position.z, left.position.z));
            }
            else
            {

                currPos = new Vector3(Random.Range(center.position.x, right.position.x), Random.Range(center.position.y, right.position.y), Random.Range(center.position.z, right.position.z));
            }
            currSpawn.transform.position = currPos;
        }

    }
}
