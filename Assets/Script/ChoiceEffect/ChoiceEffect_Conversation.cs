using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_Conversation : ChoiceEffect {
        public Conversation CV;

        public override void Effect()
        {
            base.Effect();
            ConversationControl.Main.ActivateConversation(CV);
        }
    }
}