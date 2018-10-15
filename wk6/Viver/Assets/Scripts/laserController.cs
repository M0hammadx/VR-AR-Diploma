using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserController : MonoBehaviour
{
    public enum GUN_FUNCTION
    {
        Teleport_GUN, Telekinesis_GUN
    }

    public GUN_FUNCTION gun_function;
    public LayerMask teleportLayer;
    public LayerMask grabLayer;
    public GameObject player;
    ViveHand hand;
    float TP_coolDown = 0.25f;
    Rigidbody grabbedBody;
    float time;
    LineRenderer line;
    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        hand = ViveInput.GetHand(gameObject.transform.parent.parent.gameObject);
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (ViveInput.GetTriggerValue(hand) > 0)
        {
            if (Physics.Raycast(transform.position, transform.right, out hit, 1000))
            {
                line.SetPosition(1, Vector3.right * hit.distance);
                if (ViveInput.GetTriggerValue(hand) > 0.5)
                {
                    // if (time >= TP_coolDown && gun_function == GUN_FUNCTION.Teleport_GUN && hit.collider.gameObject.layer == Mathf.Log(teleportLayer.value, 2))
                    if (time >= TP_coolDown && hit.collider.gameObject.layer == Mathf.Log(teleportLayer.value, 2))

                    {
                        player.transform.position = hit.point;
                        time = 0;
                        //  else if (time >= TP_coolDown && gun_function == GUN_FUNCTION.Telekinesis_GUN && hit.collider.gameObject.layer == Mathf.Log(grabLayer.value, 2))
                    }
                    else if (hit.collider.gameObject.layer == Mathf.Log(grabLayer.value, 2))

                    {

                        var rb = hit.collider.gameObject.GetComponent<Rigidbody>();
                        if (!rb) return;

                        hit.collider.gameObject.layer = 0;
                        grabbedBody = rb;
                        grabbedBody.transform.SetParent(transform);
                        grabbedBody.isKinematic = true;
                        grabbedBody.useGravity = false;
                    }
                }
                else if (grabbedBody)
                {
                    hit.collider.gameObject.layer = LayerMask.NameToLayer("lift");
                    grabbedBody.transform.SetParent(null);
                    grabbedBody.isKinematic = false;
                    grabbedBody.useGravity = true;
                    grabbedBody.velocity = ViveInput.GetVelocity(hand);
                    grabbedBody.angularVelocity = ViveInput.GetAngularVelocity(hand);

                    grabbedBody = null;
                }
            }
            else
            {
                line.SetPosition(1, Vector3.right * 10000);
            }
        }
        else
        {
            line.SetPosition(1, Vector3.zero);
        }
    }
}
