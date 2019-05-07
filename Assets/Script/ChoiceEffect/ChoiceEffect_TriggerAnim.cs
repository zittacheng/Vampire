using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_TriggerAnim : ChoiceEffect {
        public Animator Anim;
        public string Key;

        public override void Effect()
        {
            base.Effect();
            Anim.SetTrigger(Key);
        }
    }
}