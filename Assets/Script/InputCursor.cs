using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class InputCursor : MonoBehaviour {
        [HideInInspector]
        public static InputCursor Main;
        public bool CanInput;
        public InputArea CurrentArea;
        public List<InterObject> InterObjects;
        public List<ChoiceRenderer> CRs;
        public NPC SelectingNPC;

        // Start is called before the first frame update
        void Start()
        {
            
        }
        
        // Update is called once per frame
        void Update()
        {
            if (CanInput && CurrentArea)
            {
                if (!Room.Current)
                    Deactivate();
            }
        }

        public void FixedUpdate()
        {
            Vector3 a = TempUIControl.Main.UICamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(a.x, a.y, transform.position.z);
        }

        public void OnTriggerEnter2D(Collider2D C2D)
        {
            if (Room.Current)
            {
                if (C2D.GetComponent<InputArea>())
                {
                    CanInput = true;
                    CurrentArea = C2D.GetComponent<InputArea>();
                }
                if (C2D.GetComponent<InterObject>())
                {
                    InterObject IO = C2D.GetComponent<InterObject>();
                    if (!InterObjects.Contains(IO))
                        InterObjects.Add(IO);
                }
                if (C2D.GetComponent<ChoiceRenderer>())
                {
                    ChoiceRenderer CR = C2D.GetComponent<ChoiceRenderer>();
                    if (!CRs.Contains(CR))
                        CRs.Add(CR);
                }
                if (C2D.GetComponent<NPC>())
                {
                    SelectingNPC = C2D.GetComponent<NPC>();
                }
            }
        }

        public void OnTriggerExit2D(Collider2D C2D)
        {
            if (C2D.GetComponent<InputArea>() && C2D.GetComponent<InputArea>() == CurrentArea)
            {
                Deactivate();
            }
            if (C2D.GetComponent<InterObject>())
            {
                InterObject IO = C2D.GetComponent<InterObject>();
                if (InterObjects.Contains(IO))
                    InterObjects.Remove(IO);
            }
            if (C2D.GetComponent<ChoiceRenderer>())
            {
                ChoiceRenderer CR = C2D.GetComponent<ChoiceRenderer>();
                if (CRs.Contains(CR))
                    CRs.Remove(CR);
            }
            if (C2D.GetComponent<NPC>() && SelectingNPC == C2D.GetComponent<NPC>())
            {
                SelectingNPC = null;
            }
        }

        public InterObject GetSelectingInterObject()
        {
            if (InterObjects.Count <= 0)
                return null;
            InterObject Temp = null;
            float a = float.PositiveInfinity;
            for (int i = InterObjects.Count - 1; i >= 0; i--)
            {
                if (!InterObjects[i] || !InterObjects[i].IsActive())
                    continue;
                if ((transform.position - InterObjects[i].transform.position).magnitude < a)
                {
                    Temp = InterObjects[i];
                    a = (transform.position - InterObjects[i].transform.position).magnitude;
                }
            }
            return Temp;
        }

        public void Deactivate()
        {
            CurrentArea = null;
            CanInput = false;
        }
    }
}