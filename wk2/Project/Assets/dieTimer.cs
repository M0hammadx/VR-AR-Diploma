using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieTimer : MonoBehaviour {

    // Use this for initialization
    public int timer = 10;
	void Start () {
        Destroy(gameObject,timer);
	}
	

}
