using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Conversation : MonoBehaviour {
        public string Content;
        public ConversationChoice DefaultChoice;
        public List<ConversationChoice> Choices;
        [HideInInspector]
        public List<ConversationChoice> ActiveChoices;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnActive()
        {
            RefreshChoice();
        }

        public void RefreshChoice()
        {
            ActiveChoices = new List<ConversationChoice>();
            foreach (ConversationChoice CVC in Choices)
                if (CVC.Active())
                    ActiveChoices.Add(CVC);
        }

        public string GetContent()
        {
            return Content;
        }

        public ConversationChoice GetChoice(int Index)
        {
            if (Index < 0)
                return DefaultChoice;
            else if (ActiveChoices.Count > Index)
                return ActiveChoices[Index];
            else
                return null;
        }
    }
}