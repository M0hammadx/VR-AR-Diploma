using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{

    public LayerMask grabLayer;
    Collider[] cols;
    Rigidbody grabbedBody;

    ViveHand hand;

    // Use this for initialization
    void Start()
    {
        hand = ViveInput.GetHand(gameObject);
        cols = new Collider[10];
    }

    // Update is called once per frame
    void Update()
    {
        if (ViveInput.GetButtonDown(hand, ViveButton.Trigger))
        {
            var numberOfColliders = Physics.OverlapSphereNonAlloc(transform.position, 0.05f, cols, grabLayer);
            if (numberOfColliders == 0) return;

            var rb = cols[0].GetComponent<Rigidbody>();
            if (!rb) return;

            cols[0].gameObject.layer = 0;
            grabbedBody = rb;
            grabbedBody.transform.SetParent(transform);
            grabbedBody.isKinematic = true;
            grabbedBody.useGravity = false;
        }
        else if (ViveInput.GetButtonUp(hand, ViveButton.Trigger))
        {
            if (!grabbedBody) return;

            cols[0].gameObject.layer = LayerMask.NameToLayer("lift");
            grabbedBody.transform.SetParent(null);
            grabbedBody.isKinematic = false;
            grabbedBody.useGravity = true;
            grabbedBody.velocity = ViveInput.GetVelocity(hand);
            grabbedBody.angularVelocity = ViveInput.GetAngularVelocity(hand);

            grabbedBody = null;
        }
    }
}
