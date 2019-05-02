using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeKey : ChoiceEffect {
        public string Key;
        public int Change;

        public override void Effect()
        {
            base.Effect();
            SaveControl.SetInt(Key, SaveControl.GetInt(Key) + Change);
        }
    }
}