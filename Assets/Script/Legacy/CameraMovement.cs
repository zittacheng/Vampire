using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class CameraMovement : MonoBehaviour {
        public Character C;
        public Vector3 RelativePosition;
        public float SmoothValue;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LateUpdate()
        {
            float X = C.transform.position.x + RelativePosition.x;
            float Y = C.transform.position.y + RelativePosition.y;
            transform.position = Vector3.Lerp(transform.position, new Vector3(X, Y, transform.position.z), SmoothValue * Time.deltaTime);
        }
    }
}