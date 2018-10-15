using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fillTimer : MonoBehaviour
{

    public float speed = 0.1f;
    bool reset = false;
    Image FillImg;
    // Use this for initialization
    void Start()
    {
        FillImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GM.canHome) return;
        if (!reset) { FillImg.fillAmount = 0; reset = true; }
        FillImg.fillAmount += Time.deltaTime * speed;
        if (FillImg.fillAmount >= 1) { GameManager.GM.canHome = true; reset = false; }


    }


}
