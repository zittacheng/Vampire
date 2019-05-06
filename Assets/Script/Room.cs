using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Room : MonoBehaviour {
        [HideInInspector]
        public static Room Current {get {return OutlinersControl.Main ? OutlinersControl.Main.CurrentRoom : null;}}
        public string Key;
        public List<RoomEntrance> Entrances;
        public Vector2 CameraLimit;
        public GameObject Base;

        public void Awake()
        {
            if (SaveControl.GetString("Room") == Key)
            {
                Base.SetActive(true);
                Ini();
            }
            else
                Base.SetActive(false);
        }

        public void Ini()
        {
            int i = SaveControl.GetInt("Entrance");
            if (Entrances.Count <= i)
                i = 0;
            Character.Main.SetPosition(Entrances[i].GetCharacterPosition().x, Entrances[i].GetCharacterPosition().y);
            Character.Main.SetDirection(Entrances[i].direction);
            OutlinersControl.Main.SetRoom(this);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Vector2 GetCameraLimit()
        {
            return new Vector2(CameraLimit.x + transform.position.x, CameraLimit.y + transform.position.x);
        }
    }
}