using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_EndConversation : ChoiceEffect {

        public override void Effect()
        {
            base.Effect();
            ConversationControl.Main.DisableConversaction();
        }
    }
}