using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class PuzzleCoin : MonoBehaviour {
        public Animator Anim;
        public bool AlreadyDead;

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
            if (AlreadyDead)
                return;

            AlreadyDead = true;
            Anim.SetBool("Coin", true);
            SaveControl.SetInt("Coin", SaveControl.GetInt("Coin") + 1);
            SaveControl.SetInt("PuzzleFinished", 1);
        }
    }
}