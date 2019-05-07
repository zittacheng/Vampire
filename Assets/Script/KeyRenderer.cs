using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class KeyRenderer : MonoBehaviour {
        public string Key;
        public GameObject Base;
        public TextMeshProUGUI CountText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            int a = SaveControl.GetInt(Key);
            if (a <= 0)
                Base.SetActive(false);
            CountText.text = a.ToString();
            if (a > 0)
                Base.SetActive(true);
        }
    }
}