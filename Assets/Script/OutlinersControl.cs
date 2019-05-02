using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class OutlinersControl : MonoBehaviour {
        [HideInInspector]
        public static OutlinersControl Main;
        public Room CurrentRoom;

        public void Awake()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeRoom(Room R)
        {
            CurrentRoom = R;
            //Temp
            Camera.main.transform.position = new Vector3(R.CameraPoint.transform.position.x, R.CameraPoint.transform.position.y,
                Camera.main.transform.position.z);
        }
    }
}