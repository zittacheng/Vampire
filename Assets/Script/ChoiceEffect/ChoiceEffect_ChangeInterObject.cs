using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeInterObject : ChoiceEffect {
        public InterObject IO;
        public bool Activate;

        public override void Effect()
        {
            base.Effect();
            IO.Active = Activate;
        }
    }
}