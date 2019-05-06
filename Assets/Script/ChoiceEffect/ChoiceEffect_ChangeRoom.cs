using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect_ChangeRoom : ChoiceEffect {
        public string RoomKey;
        public int EntranceIndex;

        public override void Effect()
        {
            base.Effect();
            SaveControl.SetString("Room", RoomKey);
            SaveControl.SetInt("Entrance", EntranceIndex);
            OutlinersControl.Main.ChangeLevel();
        }
    }
}