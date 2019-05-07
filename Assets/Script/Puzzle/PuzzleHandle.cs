using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class PuzzleHandle : MonoBehaviour {
        public Animator Anim;
        public bool Animating;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnMouseDown()
        {
            if (Animating)
                return;
            StartCoroutine("ProcessIE");
        }

        public IEnumerator ProcessIE()
        {
            if (PuzzleControl.Main.NumbersCheck())
            {
                Anim.SetBool("True", true);
                yield return 0;
                Anim.SetBool("True", false);
            }
            else
            {
                Anim.SetBool("False", true);
                yield return 0;
                Anim.SetBool("False", false);
            }
        }
    }
}