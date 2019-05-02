using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class VelocitySwitch : MonoBehaviour {
        public Character C;
        public float X;
        public float Scale;
        public float Gravity = 1;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public float GetSpeed()
        {
            if (C.direction == Direction.Left)
                return -X * Scale;
            else if (C.direction == Direction.Right)
                return X * Scale;
            else
                return 0;
        }

        public float GetGravity()
        {
            return Gravity;
        }
    }
}