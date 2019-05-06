using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class PresetIOState : MonoBehaviour {
        public string Key;
        public InterObject IO;
        public Animator Anim;

        public void Awake()
        {
            if (SaveControl.GetInt(Key) == 1)
            {
                if (IO)
                    IO.Active = true;
                if (Anim)
                    Anim.SetBool("Active", true);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}