using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ClueAnim : ChoiceEffect {
        public string Content = "Random Text";

        public override void Effect()
        {
            base.Effect();
            TempUIControl.Main.PlayClueAnim(Content);
        }
    }
}