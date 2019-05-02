using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class StaticAssign : MonoBehaviour {
        public OutlinersControl OC;
        public TempUIControl TUC;
        public ConversationControl CVC;
        public InputCursor IC;
        public Character MC;
        public GhostControl GC;

        public void Awake()
        {
            if (OC)
                OutlinersControl.Main = OC;
            if (TUC)
                TempUIControl.Main = TUC;
            if (CVC)
                ConversationControl.Main = CVC;
            if (IC)
                InputCursor.Main = IC;
            if (MC)
                Character.Main = MC;
            if (GC)
                GhostControl.Main = GC;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}