using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_SetKey : ChoiceEffect {
        public string Key;
        public int Value = -1;

        public override void Effect()
        {
            base.Effect();
            SaveControl.SetInt(Key, Value);
        }
    }
}