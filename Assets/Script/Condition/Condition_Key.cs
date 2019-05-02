using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Condition_Key : Condition {
        public string Key;
        public int ValueMax = -1;
        public int ValueMin = -1;

        public override bool Active()
        {
            int a = SaveControl.GetInt(Key);
            return base.Active() && a <= ValueMax && a >= ValueMin;
        }
    }
}