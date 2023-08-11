using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float weight;
    public int flavor;
    public Color color;//field 字段 //变量

    public string 水果的名字
    {
        get
        {
            return gameObject.name+"果";
        }
    }

    public void 吃一口()
    {
        Debug.Log("味道为" + flavor);
    }

    public void 叫出名字()
    {
        //method 方法 //函数
        Debug.Log("我叫 " + 水果的名字);
    }
}
