using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TrapBreakable : MonoBehaviour
{
    public Rigidbody[] body;
    public Transform center;
    public float forceValue = 1000;

    private void OnTriggerEnter(Collider other)
    {
        var pb = other.GetComponent<PhysicsBehaviour>();
        if (pb != null && pb.myName == "玩家")
        {
            foreach (var rb in body)
            {
                rb.useGravity = true;

                var direction = rb.transform.position - center.position;
                rb.AddForce(direction.normalized * forceValue);
            }
        }
    }
}