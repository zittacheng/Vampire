using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_SetBoolAnim : ChoiceEffect {
        public Animator Anim;
        public InterObject IO;
        public bool MC;
        public string Key;

        public override void Effect()
        {
            base.Effect();
            if (Anim)
                StartCoroutine("EffectIE");
            else if (IO)
                IO.SetAnim(Key);
            else if (MC)
                Character.Main.AC.SetBoolAnim(Key);
        }

        public IEnumerator EffectIE()
        {
            Anim.SetBool(Key, true);
            yield return 0;
            Anim.SetBool(Key, false);
        }
    }
}