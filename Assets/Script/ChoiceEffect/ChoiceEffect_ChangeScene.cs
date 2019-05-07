using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeScene : ChoiceEffect {
        public string Key;

        public override void Effect()
        {
            base.Effect();
            OutlinersControl.Main.ChangeScene(Key);
        }
    }
}