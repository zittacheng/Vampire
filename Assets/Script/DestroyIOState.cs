using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class DestroyIOState : MonoBehaviour {
        public string Key;
        public InterObject IO;

        public void Awake()
        {
            if (SaveControl.GetInt(Key) == 1)
            {
                IO.gameObject.SetActive(false);
                Destroy(IO.gameObject);
            }
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