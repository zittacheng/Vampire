using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knight
{
    public class ChoiceEffect : MonoBehaviour {
        public float Delay;

        // Start is called before the first frame update
        public virtual void Start()
        {

        }

        // Update is called once per frame
        public virtual void Update()
        {

        }

        public virtual void PreEffect()
        {
            if (Delay <= 0)
                Effect();
            else
                StartCoroutine("ProcessIE");
        }

        public virtual IEnumerator ProcessIE()
        {
            yield return new WaitForSeconds(Delay);
            Effect();
        }

        public virtual void Effect()
        {

        }
    }
}