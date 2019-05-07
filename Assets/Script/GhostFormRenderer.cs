using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class GhostFormRenderer : MonoBehaviour {
        public TextMeshProUGUI TEXT;
        public TextMeshProUGUI TimeText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Character.Main.GhostForm)
            {
                TEXT.text = "Ghost Form";
                int a = (int)SaveControl.GetFloat("GhostTimeII");
                if (a >= 0)
                    TimeText.text = a.ToString();
                else
                    TimeText.text = "";
            }
            else
            {
                TEXT.text = "";
                int a = (int)SaveControl.GetFloat("GhostTime");
                if (a >= 0)
                    TimeText.text = a.ToString();
                else
                    TimeText.text = "";
            }
        }
    }
}