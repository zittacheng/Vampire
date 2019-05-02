using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ConversationChoice : MonoBehaviour {
        public string Content;
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
        }

        public void ExeEffect(ChoiceEffect E)
        {
            GameObject G = Instantiate(E.gameObject);
            G.transform.position = transform.position;
            G.GetComponent<ChoiceEffect>().PreEffect();
            Destroy(G, G.GetComponent<ChoiceEffect>().Delay + 5);
        }

        public string GetContent()
        {
            return Content;
        }

        public bool Active()
        {
            foreach (Condition Con in Conditions)
                if (!Con.Active())
                    return false;
            return true;
        }
    }
}