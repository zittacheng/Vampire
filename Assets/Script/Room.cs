using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Room : MonoBehaviour {
        public static Room Current {get {return OutlinersControl.Main ? OutlinersControl.Main.CurrentRoom : null;}}
        public InputArea inputArea;
        public List<InterObject> InterObjects;
        public GameObject CharacterPoint;
        public GameObject CameraPoint;

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