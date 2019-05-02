using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_DisruptInterObject : ChoiceEffect {

        public override void Effect()
        {
            base.Effect();
            Character.Main.DisruptInterObject();
        }
    }
}