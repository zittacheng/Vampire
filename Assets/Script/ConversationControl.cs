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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!CCV)
                MainText.text = "";
            else
                MainText.text = CCV.GetContent();
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