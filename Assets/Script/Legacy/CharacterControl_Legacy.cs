using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class CharacterControl_Legacy : MonoBehaviour {
        public Character C;
        public float InputValue;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            C.SetInputSpeed(GetSpeedInput());

            if (Input.GetButtonDown("Jump"))
                C.JumpInput();

            if (Input.GetButtonDown("Dodge"))
                C.DodgeInput();

            if (Input.GetButtonDown("AttackI"))
                C.AttackInput(0);
        }

        public float GetSpeedInput()
        {
            float a = Input.GetAxis("Horizontal");
            InputValue = a;
            if (a > 0.5f)
                a = 1;
            else if (a < -0.5f)
                a = -1;
            else
                a = 0;
            return a;
        }
    }
}