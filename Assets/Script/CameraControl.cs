using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class CameraControl : MonoBehaviour {
        public Vector3 CDifference;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float x = Character.Main.transform.position.x + CDifference.x;
            float y = Character.Main.transform.position.y + CDifference.y;
            if (Room.Current)
            {
                if (x > Room.Current.GetCameraLimit().y)
                    x = Room.Current.GetCameraLimit().y;
                if (x < Room.Current.GetCameraLimit().x)
                    x = Room.Current.GetCameraLimit().x;
            }
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}