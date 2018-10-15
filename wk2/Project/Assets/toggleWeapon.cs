using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleWeapon : MonoBehaviour {

	public void toggle()
    {
        GameManager.GM.weoponType ^= true;
    }
}
