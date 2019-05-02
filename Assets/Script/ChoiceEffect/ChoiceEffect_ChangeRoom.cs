using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeRoom : ChoiceEffect {
        public Room R;

        public override void Effect()
        {
            base.Effect();
            OutlinersControl.Main.ChangeRoom(R);
        }
    }
}