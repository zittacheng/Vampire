using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class Choice : MonoBehaviour {
        public InterObject IO;
        public string AnimKey;
        public string CharacterAnimKey;
        public bool CanDisrupt = true;
        public List<ChoiceEffect> Effects;
        public List<Condition> Conditions;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Effect()
        {
            foreach (ChoiceEffect E in Effects)
                ExeEffect(E);
            if (AnimKey != "")
                IO.SetAnim(AnimKey);
        }

        public void ExeEffect(ChoiceEffect E)
        {
            GameObject G = Instantiate(E.gameObject);
            G.transform.position = transform.position;
            G.GetComponent<ChoiceEffect>().PreEffect();
            Destroy(G, G.GetComponent<ChoiceEffect>().Delay + 5);
        }

        public bool Active()
        {
            foreach (Condition C in Conditions)
                if (!C.Active())
                    return false;
            return true;
        }
    }
}