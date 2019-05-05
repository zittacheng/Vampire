using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeRoom_Legacy : ChoiceEffect {
        public Room R;

        public override void Effect()
        {
            base.Effect();
            OutlinersControl.Main.SetRoom(R);
        }
    }
}