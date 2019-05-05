using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class ConversationControl : MonoBehaviour {
        [HideInInspector]
        public static ConversationControl Main;
        public Animator Anim;
        public TextMeshProUGUI MainText;
        public Conversation CCV;
        [Space]
        public GameObject StandardBase;
        public GameObject SingleBase;
        public GameObject DoubleBase;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!CCV)
            {
                MainText.text = "";

                StandardBase.SetActive(true);
                SingleBase.SetActive(false);
                DoubleBase.SetActive(false);
            }
            else
            {
                MainText.text = CCV.GetContent();

                if (CCV.ActiveChoices.Count == 2)
                {
                    DoubleBase.SetActive(true);
                    SingleBase.SetActive(false);
                    StandardBase.SetActive(false);
                }
                else if (CCV.ActiveChoices.Count == 1)
                {
                    DoubleBase.SetActive(false);
                    SingleBase.SetActive(true);
                    StandardBase.SetActive(false);
                }
                else
                {
                    StandardBase.SetActive(true);
                    SingleBase.SetActive(false);
                    DoubleBase.SetActive(false);
                }
            }
        }

        public void ActivateConversation(Conversation CV)
        {
            CCV = CV;
            CV.OnActive();
            Anim.SetBool("Active", true);
        }

        public void DisableConversaction()
        {
            CCV = null;
            Anim.SetBool("Active", false);
        }

        public Conversation GetCCV()
        {
            return CCV;
        }
    }
}