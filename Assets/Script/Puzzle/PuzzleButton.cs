using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class PuzzleButton : MonoBehaviour {
        public int Index;
        public int Value;

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
            PuzzleControl.Main.ChangeNumber(Index, Value);
        }
    }
}