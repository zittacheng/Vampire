using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Knight
{
    public class ChoiceRenderer : MonoBehaviour {
        public TextMeshProUGUI Text;
        public Collider Col;
        public int Index;
        public ConversationChoice CVC;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GetChoice();
            Render();
        }

        public void GetChoice()
        {
            if (ConversationControl.Main.GetCCV())
                CVC = ConversationControl.Main.GetCCV().GetChoice(Index);
            else
                CVC = null;
        }

        public void Render()
        {
            if (!CVC)
            {
                Text.text = "";
                Col.enabled = false;
            }
            else
            {
                Text.text = CVC.GetContent();
                Col.enabled = true;
            }
        }

        public void OnMouseDown()
        {
            if (CVC)
                CVC.Effect();
        }
    }
}