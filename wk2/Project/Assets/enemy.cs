using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{

    public float speed = 5;
    public int HP = 1;
    public int score = 1;
    public Text hpText;

    // Use this for initialization
    void Start()
    {
        hpText = GetComponentInChildren<Text>();
        hpText.text = HP.ToString();

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
        //Debug.Log("hit");
        if (collision.gameObject.tag == "Weapon")
        {

           // Debug.Log("hit weapon");
            HP--;
            hpText.text = HP.ToString();
            if (HP <= 0)
            {
                GameManager.GM.updateScore(score);
                Destroy(gameObject);
            }
        }
    }
}
