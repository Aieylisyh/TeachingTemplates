using UnityEngine;

namespace com
{
    public class Billboard : MonoBehaviour
    {
        public bool startOnly;

        void Start()
        {
            if (startOnly)
                Set();
        }

        void Update()
        {
            if (!startOnly)
                Set();
        }

        void Set()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}