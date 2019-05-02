using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class CharacterControl : MonoBehaviour {
        public Character C;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!InputCursor.Main)
                return;

            if (Input.GetMouseButtonDown(0))
            {
                if (InputCursor.Main.GetSelectingInterObject())
                    C.SetTargetInterObject(InputCursor.Main.GetSelectingInterObject());
                else if (InputCursor.Main.CanInput && C.CanInputMoveTarget())
                    C.SetMoveTarget(TempUIControl.Main.UICamera.ScreenToWorldPoint(Input.mousePosition).x);
            }
        }
    }
}