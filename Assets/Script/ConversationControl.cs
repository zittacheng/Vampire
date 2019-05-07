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
        public bool AnimRender;
        public float RenderDelay;
        public bool ChoiceActive;
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
                MainText.text = "";

            if (!CCV || !ChoiceActive)
            {
                StandardBase.SetActive(false);
                SingleBase.SetActive(false);
                DoubleBase.SetActive(false);
            }
            else
            {
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
            if (AnimRender)
            {
                ChoiceActive = false;
                StartCoroutine("RenderProcess");
            }
            else
            {
                ChoiceActive = true;
                MainText.text = CV.GetContent();
            }
            Anim.SetBool("Active", true);
            Update();
        }

        public IEnumerator RenderProcess()
        {
            int i = 0;
            string a = "";
            MainText.text = a;
            while (i < CCV.GetContent().Length)
            {
                yield return new WaitForSeconds(RenderDelay);
                a += CCV.GetContent()[i];
                MainText.text = a;
                i++;
            }
            ChoiceActive = true;
        }

        public void DisableConversaction()
        {
            CCV = null;
            ChoiceActive = false;
            Anim.SetBool("Active", false);
        }

        public Conversation GetCCV()
        {
            return CCV;
        }
    }
}