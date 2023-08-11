using System.Collections;
using UnityEngine;

public class PhysicsBehaviour : MonoBehaviour
{
    public string myName;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("进入触发器的范围");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("离开触发器的范围");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("开始碰撞");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("结束碰撞");
    }
}