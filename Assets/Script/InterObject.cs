using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class InterObject : MonoBehaviour {
        public GameObject InterPoint;
        public Direction InterDirection;
        public GameObject PanelPoint;
        [Space]
        public Animator Anim;
        public string DisableAnimKey;
        [Space]
        public string ActivateKey;
        public bool Active = true;
        [Space]
        public List<Choice> Choices;
        public List<Choice> ActiveChoices;
        [HideInInspector]
        public ChoicesPanel CP;

        private void Awake()
        {
            if (ActivateKey != "" && !Active && SaveControl.GetInt(ActivateKey) == 1)
                Active = true;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Activate()
        {
            //TempUIControl.Main.CreateChoicesPanel(this);
            Choice Temp = GetTargetChoice();
            if (Temp)
                Temp.Effect();
            else
                ForceDeactivate();
        }

        public void Disable()
        {
            if (CP)
            {
                TempUIControl.Main.RemoveChoicesPanel(CP);
                CP = null;
            }

            if (DisableAnimKey != "")
                SetAnim(DisableAnimKey);
        }

        public void ForceDeactivate()
        {
            if (Character.Main.ActiveInterObject == this || Character.Main.TargetInterObject == this)
                Character.Main.DisruptInterObject();
        }

        public List<Choice> GetActiveChoices()
        {
            ActiveChoices = new List<Choice>();
            foreach (Choice C in Choices)
                if (C.Active())
                    ActiveChoices.Add(C);
            return ActiveChoices;
        }

        public Choice GetTargetChoice()
        {
            GetActiveChoices();
            if (ActiveChoices.Count > 0)
                return ActiveChoices[0];
            else
                return null;
        }

        public void SetAnim(string Key)
        {
            if (Anim)
                StartCoroutine("SetAnimIE");
        }

        public IEnumerator SetAnimIE(string Key)
        {
            Anim.SetBool(Key, true);
            yield return 0;
            Anim.SetBool(Key, false);
        }

        public Vector3 GetInterPosition()
        {
            return InterPoint.transform.position;
        }

        public Direction GetInterDirection()
        {
            return InterDirection;
        }

        public Vector3 GetPanelPosition()
        {
            if (PanelPoint)
                return PanelPoint.transform.position;
            else
                return transform.position;
        }

        public Transform GetPanelTransform()
        {
            if (PanelPoint)
                return PanelPoint.transform;
            else
                return transform;
        }

        public string GetCharacterAnimKey()
        {
            Choice Temp = GetTargetChoice();
            if (Temp)
                return Temp.CharacterAnimKey;
            else
                return "";
        }

        public bool CanDisrupt()
        {
            Choice Temp = GetTargetChoice();
            if (Temp)
                return Temp.CanDisrupt;
            else
                return true;
        }

        public bool IsActive()
        {
            return Active;
        }
    }
}