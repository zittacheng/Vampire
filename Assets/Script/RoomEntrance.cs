using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class RoomEntrance : MonoBehaviour {
        public GameObject CharacterPoint;
        public Direction direction = Direction.Right;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Vector2 GetCharacterPosition()
        {
            return CharacterPoint.transform.position;
        }
    }
}