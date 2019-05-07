using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class PuzzleExit : MonoBehaviour {

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
            OutlinersControl.Main.ChangeLevel();
        }
    }
}