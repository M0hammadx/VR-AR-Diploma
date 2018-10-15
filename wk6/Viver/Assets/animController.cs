using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour
{
    bool b;
    public Material mat;
    public Material mat2;
    public SkinnedMeshRenderer g;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ViveInput.GetButtonDown(ViveHand.Left, ViveButton.Grip))
        {
            anim.SetTrigger("New Trigger");
        }
    }
    public void f1()
    {
        Debug.Log("x");
        if (b)
        {
            g.material = mat;
            b = false;
        }
        else
        {
            g.material = mat2;
            b = true;
        }
    }
}
