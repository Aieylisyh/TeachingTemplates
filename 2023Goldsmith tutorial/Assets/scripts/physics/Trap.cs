using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Rigidbody body;

    private void OnTriggerEnter(Collider other)
    {
        var pb = other.GetComponent<PhysicsBehaviour>();
        if (pb != null && pb.myName == "玩家")
        {
            body.useGravity = true;
        }
    }
}