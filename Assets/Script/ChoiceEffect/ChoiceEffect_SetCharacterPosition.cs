using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_SetCharacterPosition : ChoiceEffect {
        public GameObject CharacterPoint;

        public override void Effect()
        {
            base.Effect();
            Character.Main.SetPosition(CharacterPoint.transform.position.x, CharacterPoint.transform.position.y);
        }
    }
}