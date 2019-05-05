using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Level : MonoBehaviour {
        public string Key;
        public List<RoomEntrance> Entrances;
        public GameObject Base;

        public void Awake()
        {
            if (SaveControl.GetString("Level") == Key)
            {
                Base.SetActive(true);
                Ini();
            }
            else
                Base.SetActive(false);
        }

        public void Ini()
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
    }
}