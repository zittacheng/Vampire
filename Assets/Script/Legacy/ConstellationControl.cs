using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ConstellationControl : MonoBehaviour {
        [HideInInspector]
        public static ConstellationControl Main;
        public Character MC;
        public Animator ResetEffect;
        public Animator EndAnim;
        public string CurrentSceneName;
        [Space]
        public CheckPoint CurrentCP;

        public void Awake()
        {
            Main = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }

        public void CharacterReset()
        {
            ResetEffect.SetTrigger("Play");
        }

        public void SetCheckPoint(CheckPoint CP)
        {
            CurrentCP = CP;
        }

        public void End()
        {

        }

        public static float AbsoluteAngle(float Value)
        {
            if (Value >= 360)
                return Value - 360;
            else if (Value < 0)
                return Value + 360;
            else
                return Value;
        }
    }
}